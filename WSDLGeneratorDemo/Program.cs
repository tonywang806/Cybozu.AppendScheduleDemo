using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Services2;
using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Tokens;

namespace WSDLGeneratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string userName = "wangTianYi";
            string password = "**********";


            BaseBinding serviceProxy = new BaseBinding();
            String[] para = new String[1];
            para.SetValue(userName, 0);
            try
            {

                serviceProxy.Url = "http://cybozu.chiyodagravure.local/scripts/cbag/ag.exe?page=PApiBase";

                UsernameToken userToken = new UsernameToken(userName, password, PasswordOption.SendHashed);
                SoapContext requestContext = serviceProxy.RequestSoapContext;
                requestContext.Security.Tokens.Add(userToken);
                requestContext.Security.Timestamp.TtlInSeconds = 60;

                UserType[] users = serviceProxy.BaseGetUsersByLoginName(para);

                Console.WriteLine(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                Console.ReadLine();
            }

        }
    }
}
