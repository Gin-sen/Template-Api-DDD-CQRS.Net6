using Microsoft.AspNetCore.Mvc.Diagnostics;
using Serilog.Events;
using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace My.DDD.CQRS.Temp6.Logging.Logger
{
  public class LoggingService
  {

    /// <summary>
    /// The event hub client
    /// </summary>
    //private readonly EventHubClientProvider _eventHubClientProvider;

    /// <summary>
    /// The elk index name
    /// </summary>
    //private readonly IndexNamingService _indexNamingService;


    /// <summary>
    /// The log identifier generator service
    /// </summary>
    //private readonly UniqueIdGeneratorService _uniqueIdGeneratorService;

    /// <summary>
    /// Dictionnaire contenant les logs en attente de soumission à l'EventHub
    /// </summary>
    private readonly ConcurrentBag<LogEvent> _events = new ConcurrentBag<LogEvent>();

    private Task _runBatchTask;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggingService" /> class.
    /// </summary>
    /// <param name="provider">Name of the application.</param>
    /// <param name="applicationName">Name of the application.</param>
    public LoggingService(EventHubClientProvider provider, string applicationName)
    {
      _indexNamingService = new IndexNamingService(applicationName);
      _uniqueIdGeneratorService = new UniqueIdGeneratorService(_indexNamingService);

      _eventHubClientProvider = provider;


    }

    /// <summary>
    /// Informations the specified message.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">message Cannot be null</exception>
    /// <exception cref="System.ArgumentNullException">message Cannot be null</exception>

    public void Log(LogEvent logEvent)
    {
      if (logEvent == null)
        throw new ArgumentNullException("logEvent Cannot be null");

      _events.Add(logEvent);

      EnsureTaskRun();

    }


    private void EnsureTaskRun()
    {
      if (_runBatchTask == null || _runBatchTask.IsFaulted || _runBatchTask.IsCompleted || _runBatchTask.IsCanceled)
        RunBatch();
    }

    private void RunBatch()
    {
      _runBatchTask = Task.Run(async () =>
      {
        byte failCount = 0;
        List<LogEvent> selected = new List<LogEvent>();
        while (true)
        {
          try
          {
            if (_events.Count == 0)
              await Task.Delay(10000);

            for (int i = 0; i < 25; i++)
            {
              if (_events.TryTake(out LogEvent logevent))
              {
                selected.Add(logevent);
              }
              else
              {
                break;
              }
            }
            if (selected.Count > 0)
            {
#if NET462
              await _eventHubClientProvider.GetClientInstance().SendBatchAsync(selected.Select(e => MapToEventData(e)).ToList()).ConfigureAwait(false);
#else
              await _eventHubClientProvider.GetClientInstance().SendAsync(selected.Select(e => MapToEventData(e)).ToList()).ConfigureAwait(false);
#endif
              selected.Clear();
            }
          }
          catch (Exception e)
          {
            if (++failCount > 5) throw new Exception("Logging Service RunBatch Fail", e);
          }
        }
      });

    }

    /// <summary>
    /// Logs the asynchronous.
    /// </summary>
    /// <param name="logs">The logs.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">logEvent Cannot be null</exception>
    private async Task LogAsync(IEnumerable<LogEvent> logs)
    {
      if (logs == null)
        throw new ArgumentNullException("logEvent Cannot be null");

      foreach (LogEvent e in logs)
      {
        _events.Add(e);
      }
      EnsureTaskRun();

      //await _eventHubClientProvider.GetClientInstance().SendAsync(logs.Select(l => MapToEventData(l))).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps the log dto.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">logEvent Cannot be null
    /// or
    /// logEvent.message Cannot be null</exception>
    private EventData MapToEventData(LogEvent logEvent)
    {
      if (logEvent == null)
        throw new ArgumentNullException("logEvent Cannot be null");

      JObject resultJo = JObject.FromObject(new InternalLogDto()
      {
        LogId = _uniqueIdGeneratorService.GetuniqueId(),
        IndexName = _indexNamingService.GetIndexName(),
        Level = logEvent.Level.ToString(),
        Message = logEvent.Message,
      });

      var dicoJo = resultJo as IDictionary<string, JToken>;

      if (logEvent.Data != null)
      {
        string fieldPrefix;

        if (logEvent.Data is Exception)
        {
          fieldPrefix = "exceptions";
        }
        else
        {
          fieldPrefix = "fields";
          logEvent.Data = SerializeObject(logEvent.Data);
        }

        if (logEvent.Data.GetType().IsArray)
        {
          JArray array = JArray.FromObject(logEvent.Data);
          int counter = 0;
          foreach (var prop in array)
          {
            if (prop.Type == JTokenType.Object)
            {
              string key;
              foreach (var field in ((JObject)prop))
              {
                int keyCounter = 0;
                key = $"{fieldPrefix}.{field.Key}";
                while (dicoJo.ContainsKey(key))
                  key = $"{fieldPrefix}.{field.Key}{++keyCounter}";

                resultJo.Add(key, field.Value);
              }
            }
            else
              resultJo.Add($"{fieldPrefix}.array{++counter}", prop);
          }
        }
        else
        {
          JObject data = JObject.FromObject(logEvent.Data);
          foreach (var prop in data)
          {

            resultJo.Add($"{fieldPrefix}.{prop.Key}", prop.Value);
          }
        }
      }
      return new EventData(Encoding.UTF8.GetBytes(resultJo.ToString()));
    }



    /// <summary>
    /// Méthode de serialisation récursive des objets
    /// </summary>
    /// <param name="fields"></param>
    /// <returns></returns>
    private IDictionary<string, object> SerializeObject(object fields, string prefix = null, IDictionary<string, object> objects = null)
    {
      if (objects == null)
        objects = new ExpandoObject();

      var exception = fields as Exception;
      if (exception != null)
      {
        objects.Add("Exception", exception.Message);
        objects.Add("Exception.Details", exception);
        return objects;
      }

      var _fields = fields as object[];
      if (_fields == null)
      {
        // Cas particulier si c'est une liste
        //if (fields.GetType().IsGenericType && fields.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
        if (fields.GetType().GetInterface("ICollection") != null)
        {
          int count = 1;
          foreach (var item in (ICollection)fields)
          {
            string _prefix = string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.{count}";
            foreach (var val in SerializeObject(item, count.ToString()))
            {
              objects.Add(val.Key, val.Value);
            }
            ++count;
          }
        }
        else
        {
          SerializeProperty(objects, fields, prefix);
        }
      }
      else
      {
        foreach (object field in (object[])fields)
        {


          SerializeProperty(objects, field, prefix);

        }
      }
      return objects;
    }

    private void SerializeProperty(IDictionary<string, object> objects, object field, string prefix = null)
    {
      if (field == null)
        return;

      var fields = field as object[];
      if (fields == null)
      {

        if (field.GetType().GetInterface("ICollection") != null)
        {
          int count = 1;
          foreach (var item in (ICollection)field)
          {
            string _prefix = string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.{count}";
            foreach (var val in SerializeObject(item, count.ToString()))
            {
              objects.Add(val.Key, val.Value);
            }
            ++count;
          }
        }
        else
        {
          var type = field.GetType();
          SerializeProperties(objects, field, prefix, type);
          SerializeFields(objects, field, prefix, type);
        }
      }
      else
      {
        foreach (object _field in (object[])fields)
        {
          SerializeProperty(objects, _field, prefix);
        }
      }
    }

    private void SerializeFields(IDictionary<string, object> objects, object field, string prefix, Type type)
    {
      var reflectedFields = type.GetFields();
      foreach (var fi in reflectedFields)
      {
        object value = field == null ? null : fi.GetValue(field);

        if (value != null && value.GetType().IsClass && value.GetType() != typeof(string))
        {
          //string _prefix = prefix + $".{pi.Name}";
          string _prefix = string.IsNullOrEmpty(prefix) ? fi.Name : $"{prefix}.{fi.Name}";
          foreach (var val in SerializeObject(value, _prefix))
          {
            objects.Add(val.Key, val.Value);
          }
        }
        else
        {
          string name = string.IsNullOrEmpty(prefix) ? fi.Name : $"{prefix}.{fi.Name}";
          objects.Add(name, value);
        }
      }
    }

    private void SerializeProperties(IDictionary<string, object> objects, object field, string prefix, Type type)
    {
      var props = type.GetProperties();
      foreach (PropertyInfo pi in props)
      {
        object value = field == null ? null : pi.GetValue(field);

        if (value != null && value.GetType().IsClass && value.GetType() != typeof(string))
        {
          //string _prefix = prefix + $".{pi.Name}";
          string _prefix = string.IsNullOrEmpty(prefix) ? pi.Name : $"{prefix}.{pi.Name}";
          foreach (var val in SerializeObject(value, _prefix))
          {
            objects.Add(val.Key, val.Value);
          }
        }
        else
        {
          string name = string.IsNullOrEmpty(prefix) ? pi.Name : $"{prefix}.{pi.Name}";
          objects.Add(name, value);
        }
      }
    }
  }
}
