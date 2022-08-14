using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProjectValidator:AbstractValidator<Project>
    {
        public ProjectValidator()
        {

            RuleFor(p => p.LeadById).NotEmpty();
            RuleFor(p => p.AssignedById).NotEmpty();
            RuleFor(P => P.CustomerId).NotEmpty();
            RuleFor(p => p.ProjectName).NotEmpty();
            RuleFor(P => P.Status).NotEmpty();
            RuleFor(p=>p.StartedAt).NotEmpty();

            RuleFor(p => p.ProjectName).MinimumLength(6);
           


        }
       
    

    }
}
