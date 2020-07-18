using Bogus;
using DesafioBoltons.Domain.DTOs;
using DesafioBoltons.Domain.Entities;
using DesafioBoltons.Service.Validators;
using DesafioBoltons.Tests.Extensoes;
using Xunit;

namespace DesafioBoltons.Tests.Entidades
{
    public class NFeEntityTeste
    {
        private readonly NFeDTO _modelo;
        private readonly NFeValidator _validador;

        public NFeEntityTeste()
        {
            _modelo = new Faker<NFeDTO>("pt_BR")
                .RuleFor(b => b.access_key, f => f.Lorem.Sentence())
                .RuleFor(b => b.xml, f => f.Lorem.Text())
                .Generate();

            _validador = new NFeValidator();
        }

        private NFeEntity CriarInstanciaNFe() => new NFeEntity(_modelo.access_key, _modelo.xml);

        [Theory]
        [InlineData("", "A CHAVE DE ACESSO é obrigatória.")]
        [InlineData(null, "A CHAVE DE ACESSO é obrigatória.")]
        public void NaoPermitirCriarSemChaveAcesso(string valor, string esperado)
        {
            _modelo.access_key = valor;
            var nfe = CriarInstanciaNFe();
            var validacao = _validador.Validate(nfe);

            Assert.False(validacao.IsValid);
            Assert.True(validacao.Errors.ValidarMensagemRetorno(esperado));
        }

        [Theory]
        [InlineData("", "O XML é obrigatório.")]
        [InlineData(null, "O XML é obrigatório.")]
        public void NaoPermitirCriarSemXML(string valor, string esperado)
        {
            _modelo.xml = valor;
            var nfe = CriarInstanciaNFe();
            var validacao = _validador.Validate(nfe);

            Assert.False(validacao.IsValid);
            Assert.True(validacao.Errors.ValidarMensagemRetorno(esperado));
        }
    }
}
