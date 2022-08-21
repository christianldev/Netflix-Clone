using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using netflix_api_domain.Commons;

namespace netflix_api_domain.Entities;

public class Customer : AuditableBaseEntity
{

    private int _age;
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public char Status { get; set; }


    // Calculo de edad a partir de la fecha de nacimiento, verificar si es un usuario mayor o menor de edad
    public int Age
    {
        get
        {
            if (this._age <= 0)
            {
                this._age = new DateTime(DateTime.Now.Subtract(this.BirthDate).Ticks).Year - 1;
            }

            return this._age;
        }
    }

}
