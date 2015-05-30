using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace Service
{
    class UserNamePassValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "test" && password == "test"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}