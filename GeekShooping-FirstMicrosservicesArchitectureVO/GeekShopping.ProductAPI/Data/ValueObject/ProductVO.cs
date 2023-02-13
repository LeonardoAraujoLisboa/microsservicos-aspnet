using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductAPI.Data.ValueObject
{
    public class ProductVO //é ume espelho da nossa entidade, da tabela mesmo. Crio o VO por segurança (pois sem ele o usuário consegue visualizar toda a estrutura do banco) e tbm pra facilitar a alteração de algo ai da tabela
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
