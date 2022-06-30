﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsManagement.Registrations
{
    internal class SqlQueriesParameterised
    {

        private static readonly string ConnectionString = "Server=tcp:s126t01-shared-sql.database.windows.net,1433;Database=s126t01-resac-db;User ID=resac-testsuite-rw-svc;Password=7kC#R*7bBwB;Trusted_Connection=False;Pooling=True;Connect Timeout=30;MultipleActiveResultSets=True";
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

     
        public static void CreateRegistration(string uln, string CreateCoreGrade, string CreateSpecialismGrade, string Year)
        {
            var profileId = CreateRegistrationProfileForLrsWithEM(uln);
            var pathwayId = CreateRegistrationPathwayForLrs(profileId, Year);
            CreateRegSpecialismForLrs(pathwayId);
            var pathwayAssessmentId = CreatePathwayAssessment(pathwayId);

            if (CreateCoreGrade != "N")
            {
             CreatePathwayResult(pathwayAssessmentId, CreateCoreGrade);
            }
                       
            //CreateQualificationAcheivedForLrs(profileId);
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
        public static int CreateRegistrationPathwayForLrs(int profileId, string Year)
        {
            var tqProviderId = Constants.TqProviderIdForLrs;
            var createRegPathway = "Insert into TqRegistrationPathway values('" + profileId + "', '" + tqProviderId + "','" + Year + "', GETDATE(),NULL,1,1,GETDATE(),'System',NULL,NULL)";
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

        public static void CreatePathwayResult(int pathwayAssessmentId, string Grade)
        {
            string LookupGrade = "";
            if (Grade == "A*") { LookupGrade = "1"; }
            else if  (Grade == "A") { LookupGrade = "2"; }
            else if  (Grade == "B") { LookupGrade = "3"; }
            else if (Grade == "C") { LookupGrade = "4"; }
            else if (Grade == "D") { LookupGrade = "5"; }
            else if (Grade == "E") { LookupGrade = "6"; }
            else if (Grade == "U") { LookupGrade = "7"; }



            var createPathwayResult = "Insert into TqPathwayResult values('" + pathwayAssessmentId + "'," + LookupGrade + ",GETDATE(),NULL,Null,1,0,GETDATE(),'SYSTEM',NULL,'SYSTEM')";
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
