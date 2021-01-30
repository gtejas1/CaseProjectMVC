using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseProjectMVC.Models
{
    public class validateDOB : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (Convert.ToDateTime(value) > DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        
    }
}