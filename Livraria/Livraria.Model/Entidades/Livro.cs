using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Model.Entidades
{
    public class Livro
    {
        public Livro()
        {

        }

        public virtual int codigoLiv { get; set; }
        public virtual string nomeLiv { get; set; }
        public virtual string escritLiv { get; set; }
        public virtual string editorLiv { get; set; }
        public virtual float? precoLiv { get; set; }
        public virtual int? qtdpagLiv { get; set; }
        public virtual int qtdestLiv { get; set; }
    }

    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Table("Livro");
            Id(x => x.codigoLiv).Column("codigo_liv").Not.Nullable().GeneratedBy.Identity();
            Map(x => x.nomeLiv).Column("nome_liv").Not.Nullable();
            Map(x => x.escritLiv).Column("escrit_liv").Nullable();
            Map(x => x.editorLiv).Column("editor_liv").Nullable();
            Map(x => x.precoLiv).Column("preco_liv").Nullable();
            Map(x => x.qtdpagLiv).Column("qtdpag_liv").Nullable();
            Map(x => x.qtdestLiv).Column("qtdest_liv").Not.Nullable();
        }
    }
}
