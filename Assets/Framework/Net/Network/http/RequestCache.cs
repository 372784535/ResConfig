using System.Collections.Generic;
using Network.http;

public class RequestCache  
{
    //ms
    private long time = 60000;

    private Dictionary<string, MyHttpResult> requestCacheList = new Dictionary<string, MyHttpResult>();
    private Dictionary<string, long> UpdateTimeList = new Dictionary<string, long>();

    public void UpdateRequestCache(string key, MyHttpResult result)
    {
        if (key == null)
            return;

        if (CanUpdate(key))
        {
            if (requestCacheList.ContainsKey(key))
            {
                requestCacheList[key] = result;
                UpdateTimeList[key] = ToolUtil.currentTimeMillis;
            }
            else
            {
                requestCacheList.Add(key, result);
                UpdateTimeList[key] = ToolUtil.currentTimeMillis;
            }
        }
    }

    public MyHttpResult getResult(string key)
    {
        if (requestCacheList.ContainsKey(key))
        {
            return requestCacheList[key];
        }
        else
        {
            AddNewCache(key);
            return null;
        }       
    }
    
    public bool CanUpdate(string key)
    {
        if (UpdateTimeList.ContainsKey(key))
        {
            if (ToolUtil.currentTimeMillis - UpdateTimeList[key] <= time)
            {
                if (requestCacheList[key] == null)
                {
                    return true;
                }
                return false;
            }
        }
        AddNewCache(key);
        return true;
    }
    public void AddNewCache(string key)
    {
        if (!requestCacheList.ContainsKey(key))
        {
            requestCacheList.Add(key, null);
            UpdateTimeList.Add(key, 0);
        }       
    }
    public void ClearCache(string key)
    {
        if (requestCacheList.ContainsKey(key))
        {
            requestCacheList.Remove(key);
            UpdateTimeList.Remove(key);
        }      
    }
    public void ClearAllCache()
    {
        requestCacheList.Clear();
        UpdateTimeList.Clear();
    }
}
