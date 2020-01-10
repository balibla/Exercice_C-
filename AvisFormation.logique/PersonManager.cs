using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvisFormation.Data;

namespace AvisFormation.logique
{
    public class PersonManager
    {
        public void InsertPerson(string user_id, string nom)
        {
            using (var context = new AvisEntitis())
            {
                var person = context.Person.Where(f => f.user_id == user_id).FirstOrDefault();
                if (person == null)
                {
                    Person p = new Person();
                    p.Nom = nom;
                    p.user_id = user_id;

                    context.Person.Add(p);
                    context.SaveChanges();
                }
               
            }
        }
        public string GetNameByUserId(string user_id)
        {
            using(var context = new AvisEntitis())
            {
                var namePerson = context.Person.Where(f => f.user_id == user_id).FirstOrDefault();
                    if (namePerson == null)
                {
                    return "Anonyme";
                   
                }
                else
                {
                    return namePerson.Nom;
                }
            }
        }
        public bool IsExiste(string user_id, int formationId)
        {
            Avis avi;
            using (var context = new AvisEntitis())
            {
                avi = context.Avis.FirstOrDefault(a => a.IdFormation == formationId && a.UserId == user_id);
            }
            return (avi != null) ? true : false;
        }
    }
}
