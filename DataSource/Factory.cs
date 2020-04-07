namespace DataSource
{
    enum DataReader
    {
        settingsData,
        postprocesorsData
        
    }

    public class Factory
    {
        public static BaseDataReader<BaseData> GetReader(int someType)
        {
            BaseDataReader<BaseData> ret = null;
            if (someType == (int) DataReader.postprocesorsData)
                ret = new PostprocesorsData();
            else if (someType == (int) DataReader.settingsData)
                ret = new SettingsData();
            return ret;
        }
    }
}
