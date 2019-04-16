using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class UsuarioModel
    {
        public static UsuarioViewModel Usuario(string id)
        {
            using (var context = new autenticadorEntities())
            {
                Guid _id = new Guid(id);
                return new UsuarioViewModel(context.usuario.Find(_id));
            }
        }
        public static IEnumerable<UsuarioViewModel> Usuarios(UsuarioViewModel filter = null)
        {
            //throw new Exception("Errou");

            using (var context = new autenticadorEntities())
            {
                var usuarios = new List<UsuarioViewModel>();

                IQueryable<usuario> query = context.Set<usuario>();

                if (filter != null)
                {
                    if (!string.IsNullOrEmpty(filter.Id))
                    {
                        Guid Id = new Guid(filter.Id);
                        query = query.Where(n => n.usu_id_usuario == Id);
                    }
                    if (!string.IsNullOrEmpty(filter.Nome))
                    {
                        query = query.Where(n => n.usu_ds_nome.Contains(filter.Nome));
                    }
                    if (!string.IsNullOrEmpty(filter.CPF))
                    {
                        string CPF = filter.CPF.Replace("-", "").Replace(".", "").Replace(" ", "");
                        query = query.Where(n => n.usu_ds_cpf.Replace("-", "").Replace(".", "").Replace(" ", "") == CPF);
                    }
                }

                query.ToList().ForEach(obj =>
                {
                    usuarios.Add(new UsuarioViewModel(obj));
                });

                return usuarios;
            }
        }
    }

    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public UsuarioViewModel() { }
        public UsuarioViewModel(usuario usuario)
        {
            this.Nome = usuario.usu_ds_nome;
        }
    }
}