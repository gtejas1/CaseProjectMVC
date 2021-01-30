using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaseProjectMVC.Models
{
    public class DBOperations
    {
        static ProjectDataBaseEntities4 P = null;
        static List<Member> L = null;
        static List<Application> Al = null;
        static Application A = null;
        static int mID=0;
        static int aID=1;
        public DBOperations()
        {
            //P = new ProjectDataBaseEntities();
        }
        static public string AddMember(Member M)
        {
            P = new ProjectDataBaseEntities4();
            if (P.Members.Count() > 0 && L==null)
            {
                
                mID = P.Members.Count();
                var v = from v1 in P.Applications
                        where v1.Memberid==mID
                        select v1.ApplicationId;
                aID = (int)v.First()+1;
            }
            mID++;
            A=new Application();
            if (Al != null)
            {
                A.ApplicationId = aID;
            }
            else
            {
                A.ApplicationId = aID;
                L = new List<Member>();
                Al = new List<Application>();
            }
            
            M.Memberid = mID;
            A.Memberid = mID;
            L.Add(M);
            Al.Add(A);
            return "added";    
        }
        static public string SaveMember()
        {
            P = new ProjectDataBaseEntities4();
            try
            {
                P.Members.AddRange(L);
                P.Applications.AddRange(Al);
                //for (int i = 0; i < L.Count(); i++)
                //{
                //    Member m = L.ElementAt(i);
                //    P.Members.Add(m);
                //}
                P.SaveChanges();
                L = null;
                Al = null;
                aID++;
                return "saved";    
                
            }
            catch(DbUpdateException d)
            {
                SqlException s = d.GetBaseException() as SqlException;
                //if (s.Message.Contains("PRIMARY KEY"))
                //{
                //    for (int i = 0; i < L.Count(); i++)
                //    {
                //        Member m = L.ElementAt(i);
                //        int c = P.Applications.Last().Memberid;//some notsupportedException occured
                //        m.Memberid = c + i + 1;
                //        Application A=Al.ElementAt(i);
                //        A.Memberid = c + i + 1;
                //        P.Members.Add(m);
                //        P.Applications.Add(A);
                //    }
                //    P.SaveChanges();
                //}
                return (s.Message);
            }
            catch (NullReferenceException n)
            {
                return (n.Message);
            }
            
        }
        static public string loggin(Login L)
        {
            P=new ProjectDataBaseEntities4();
            
                var v = from v1 in P.Logins
                        where v1.Usertype == L.Usertype && v1.Password==L.Password && v1.Username==L.Username
                        select v1;
                if(v.Count()>0){
                        if (L.Usertype == "admin")
                            return ("successad");
                        else if(L.Usertype == "applicant")  //&& v.First().Usertype=="applicant")
                            return ("successap");
                        }
                return ("Invalid data");
         }
            
        static public List<Member> fetch(int id)
        {
            P=new ProjectDataBaseEntities4();
            
            List<Member> Lm = new List<Member>();
            var v = from v1 in P.Applications
                    where v1.ApplicationId == id
                    select v1;
            for (int i = v.First().Memberid; i < v.Count() + v.First().Memberid; i++)
            {
                var v2 = from v3 in P.Members
                        where v3.Memberid==i
                        select v3;
                Lm.Add(v2.First());
            }
            return (Lm);
        }
    }
}