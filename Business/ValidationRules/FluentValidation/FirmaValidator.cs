using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FirmaValidator:AbstractValidator<Firma>
    {
        public FirmaValidator()
        {
            RuleFor(f => f.FirmaAdi.Trim()).Length(3, 30);
            RuleFor(f => f.FirmaTelefonu.Trim()).Length(11);
            RuleFor(f => f.YetkiliAdi.Trim()).Length(3, 30);
            RuleFor(f => f.YetkiliTelefonNo.Trim()).Length(11);
            RuleFor(f => f.Aciklama.Trim().Length).LessThan(300);
            RuleFor(f => f.COGorusmeDetayi.Trim().Length).LessThan(300);
            RuleFor(f => f.FirmaninAlarmIstemedigineDairYazi.Trim().Length).LessThan(300);
            RuleFor(f => f.TepeNot.Trim().Length).LessThan(300);
            RuleFor(f => f.SahaRevizeNot.Trim().Length).LessThan(300);
        }
    }
}
