using FinalExam.Configuration;
using FinalExam.Constants;
using FinalExam.DataBase.Entities;

namespace FinalExam.DataBase.DataContext
{
    public class LiteratureReferenceRepository
    {
        public BaseDb<RfamContext, LiteratureReferenceEntity> LiteratureRefRepository { get; }

        public LiteratureReferenceRepository()
        {
            var connectionString = ConfigurationProvider.GetConfigurationValue[AppConstants.DBConnectionString];
            LiteratureRefRepository = new BaseDb<RfamContext, LiteratureReferenceEntity>(connectionString!);
        }
    }
}