using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsManagement.Registrations
{
    internal class SqlQueries
    {

        private static readonly string ConnectionString = "";
        private const string UlnList = "select Id,UniqueLearnerNumber,Firstname,Lastname,DateofBirth from TqRegistrationProfile";
        //Delete from Registration Tables
        private const string DeleteRegistrationSpecialism = "Delete rs from TqRegistrationSpecialism rs join TqRegistrationPathway rw ON rs.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber like '9%'";
        private const string DeleteRegistrationPathway = "Delete from TqRegistrationPathway where TqRegistrationProfileId In (select Id from TqRegistrationProfile where UniqueLearnerNumber like '9%')";
        private const string DeleteRegistrationProfile = "Delete from TqRegistrationProfile where UniqueLearnerNumber like '9%'";
        private const string DeleteAssessmentPathway = "Delete pa from TqPathwayAssessment pa join TqRegistrationPathway rw ON pa.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber like '9%'";
        private const string DeleteAssessmentSpecialism = "Delete sa from TqSpecialismAssessment sa join TqRegistrationSpecialism rs ON sa.TqRegistrationSpecialismId = rs.Id join TqRegistrationPathway rp on  rs.TqRegistrationPathwayId=rp.Id join TqRegistrationProfile tr on  rp.TqRegistrationProfileId =tr.Id where UniqueLearnerNumber like '9%'";
        private const string DeletePathwayResults = "Delete pr from TqPathwayResult pr join TqPathwayAssessment pa on pr.TqPathwayAssessmentId = pa.Id join TqRegistrationPathway rw ON pa.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber like '9%'";
        private const string DeleteAssessmentResult = "Delete sr from TqSpecialismResult sr join TqSpecialismAssessment sa on sr.TqSpecialismAssessmentId = sa.Id join TqRegistrationSpecialism rs ON sa.TqRegistrationSpecialismId = rs.Id join TqRegistrationPathway rp on  rs.TqRegistrationPathwayId=rp.Id join TqRegistrationProfile tr on  rp.TqRegistrationProfileId =tr.Id where UniqueLearnerNumber like '9%'";
        private const string DeleteIpData = "Delete ip from IndustryPlacement ip join TqRegistrationPathway pw on ip.TqRegistrationPathwayId = pw.Id join TqRegistrationProfile rp on rp.Id=pw.TqRegistrationProfileId where rp.UniqueLearnerNumber like '9%'";
        private const string DeleteEmData = "Delete qa from QualificationAchieved qa join TqRegistrationProfile rp on qa.TqRegistrationProfileId = rp.Id where rp.UniquelearnerNumber like '9%'";

        public static void DeleteFromRegistrationTables()
        {
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteIpData, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteEmData, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteAssessmentResult, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeletePathwayResults, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteAssessmentPathway, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteAssessmentSpecialism, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteRegistrationSpecialism, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteRegistrationPathway, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteRegistrationProfile, ConnectionString);
        }

        public static void DeleteSingleRegistration(string SingleULN)
        {
           string DeleteSingleRegistrationSpecialism = "Delete rs from TqRegistrationSpecialism rs join TqRegistrationPathway rw ON rs.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber = " + SingleULN;
           string DeleteSingleRegistrationPathway = "Delete from TqRegistrationPathway where TqRegistrationProfileId In (select Id from TqRegistrationProfile where UniqueLearnerNumber=" + SingleULN + ")";
           string DeleteSingleRegistrationProfile = "Delete from TqRegistrationProfile where UniqueLearnerNumber=" + SingleULN;
           string DeleteSingleAssessmentPathway = "Delete pa from TqPathwayAssessment pa join TqRegistrationPathway rw ON pa.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber=" + SingleULN;
           string DeleteSingleAssessmentSpecialism = "Delete sa from TqSpecialismAssessment sa join TqRegistrationSpecialism rs ON sa.TqRegistrationSpecialismId = rs.Id join TqRegistrationPathway rp on  rs.TqRegistrationPathwayId=rp.Id join TqRegistrationProfile tr on  rp.TqRegistrationProfileId =tr.Id where UniqueLearnerNumber =" + SingleULN;
           string DeleteSinglePathwayResults = "Delete pr from TqPathwayResult pr join TqPathwayAssessment pa on pr.TqPathwayAssessmentId = pa.Id join TqRegistrationPathway rw ON pa.TqRegistrationPathwayId = rw.Id join TqRegistrationProfile rp on rw.TqRegistrationProfileId =rp.Id where UniqueLearnerNumber=" + SingleULN;
           string DeleteSingleAssessmentResult = "Delete sr from TqSpecialismResult sr join TqSpecialismAssessment sa on sr.TqSpecialismAssessmentId = sa.Id join TqRegistrationSpecialism rs ON sa.TqRegistrationSpecialismId = rs.Id join TqRegistrationPathway rp on  rs.TqRegistrationPathwayId=rp.Id join TqRegistrationProfile tr on  rp.TqRegistrationProfileId =tr.Id where UniqueLearnerNumber=" + SingleULN;
           string DeleteSingleIpData = "Delete ip from IndustryPlacement ip join TqRegistrationPathway pw on ip.TqRegistrationPathwayId = pw.Id join TqRegistrationProfile rp on rp.Id=pw.TqRegistrationProfileId where rp.UniqueLearnerNumber=" + SingleULN;
           string DeleteSingleEmData = "Delete qa from QualificationAchieved qa join TqRegistrationProfile rp on qa.TqRegistrationProfileId = rp.Id where rp.UniquelearnerNumber=" + SingleULN;


        SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleIpData, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleEmData, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleAssessmentResult, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSinglePathwayResults, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleAssessmentPathway, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleAssessmentSpecialism, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleRegistrationSpecialism, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleRegistrationPathway, ConnectionString);
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteSingleRegistrationProfile, ConnectionString);
        }


        public static void CreateDbRegWithIpForLrs(string uln, int status)
        {
            var profileId = CreateRegistrationProfileForLrsWithEM(uln);
            var pathwayId = CreateRegistrationPathwayForLrs(profileId);
            CreateRegSpecialismForLrs(pathwayId);
            var pathwayAssessmentId = CreatePathwayAssessment(pathwayId);
            CreatePathwayResult(pathwayAssessmentId);
            CreateQualificationAcheivedForLrs(profileId);
            //CreateIndustryPlacement(pathwayId, status);
        }
        public static int CreateRegistrationProfileForLrsWithEM(string uln)
        {
            var createRegistrationProfile = "Insert into TqRegistrationProfile values(" + uln + ", 'Db FirstName','Db LastName','2001-01-01',Null,1,1,Null,0,3,3,GETDATE(),'System', GETDATE(),'System')";
            var getRegProfileId = "Select top 1 id from TqRegistrationProfile where UniqueLearnerNumber='" + uln + "'";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createRegistrationProfile, ConnectionString);
            var profileId = SqlDatabaseConncetionHelper.ReadDataFromDataBase(getRegProfileId, ConnectionString);
            return (int)profileId.FirstOrDefault().FirstOrDefault();
        }
        public static int CreateRegistrationPathwayForLrs(int profileId)
        {
            var tqProviderId = Constants.TqProviderIdForLrs;
            var createRegPathway = "Insert into TqRegistrationPathway values('" + profileId + "', '" + tqProviderId + "','2020', GETDATE(),NULL,1,1,GETDATE(),'System',NULL,NULL)";
            var getRegPathwayId = "select top 1 id from TqRegistrationPathway where TqRegistrationProfileId = '" + profileId + "'";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createRegPathway, ConnectionString);
            var pathwayId = SqlDatabaseConncetionHelper.ReadDataFromDataBase(getRegPathwayId, ConnectionString);
            return (int)pathwayId.FirstOrDefault().FirstOrDefault();
        }

        public static int CreateRegSpecialismForLrs(int pathwayId)
        {
            var tlSpecialismId = Constants.TlSpecialismId;
            var createRegSpecialism = "Insert into TqRegistrationSpecialism values('" + pathwayId + "','" + tlSpecialismId + "',GETDATE(),NULL,1,0,GETDATE(),'System',Null,Null )";
            var getSpecialismId = "select top 1 id from TqRegistrationSpecialism where TqRegistrationPathwayId  = '" + pathwayId + "'";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createRegSpecialism, ConnectionString);
            var specialismId = SqlDatabaseConncetionHelper.ReadDataFromDataBase(getSpecialismId, ConnectionString);
            return (int)specialismId.FirstOrDefault().FirstOrDefault();
        }

        public static int CreatePathwayAssessment(int pathwayId)
        {
            var createPathwayAssessment = "Insert into TqPathwayAssessment values('" + pathwayId + "',1,GETDATE(),NULL,1,0,GETDATE(),'System',Null,Null )";
            var getRegPathwayId = "select top 1 id from TqPathwayAssessment where TqRegistrationPathwayId  = '" + pathwayId + "'";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createPathwayAssessment, ConnectionString);
            var regPathwayId = SqlDatabaseConncetionHelper.ReadDataFromDataBase(getRegPathwayId, ConnectionString);
            return (int)regPathwayId.FirstOrDefault().FirstOrDefault();
        }

        public static void CreatePathwayResult(int pathwayAssessmentId)
        {
            var createPathwayResult = "Insert into TqPathwayResult values ('" + pathwayAssessmentId + "',2,GETDATE(),NULL,Null,1,0,GETDATE(),'SYSTEM',NULL,'SYSTEM')";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createPathwayResult, ConnectionString);
        }

        public static void CreateQualificationAcheivedForLrs(int profileId)
        {
            var createQualificationAcheived = "Insert into QualificationAchieved values ('" + profileId + "',38,8,1,GETDATE(),'SYSTEM',GETDATE(),'SYSTEM')";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createQualificationAcheived, ConnectionString);

            var createQualificationAcheived1 = "Insert into QualificationAchieved values ('" + profileId + "',69,8,1,GETDATE(),'SYSTEM',GETDATE(),'SYSTEM')";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createQualificationAcheived1, ConnectionString);
        }

        public static void CreateIndustryPlacement(int pathwayId, int status)
        {
            var createIpData = "Insert into IndustryPlacement values ('" + pathwayId + "','" + status + "',GETDATE(),'SYSTEM',GETDATE(),'SYSTEM')";
            SqlDatabaseConncetionHelper.ExecuteSqlCommand(createIpData, ConnectionString);
        }

        public static List<long> UlnListFromDb()
        {
            var result = SqlDatabaseConncetionHelper.GetFieldValue(UlnList, ConnectionString);
            return result.Select(x => (long)x[1]).ToList();
        }
    }
}
