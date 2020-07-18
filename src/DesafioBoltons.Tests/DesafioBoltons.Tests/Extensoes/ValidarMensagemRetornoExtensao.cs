using FluentValidation.Results;
using System.Collections.Generic;

namespace DesafioBoltons.Tests.Extensoes
{
    public static class ValidarMensagemRetornoExtensao
    {
        public static bool ValidarMensagemRetorno(this IList<ValidationFailure> erros, string mensagemEsperada)
        {
            foreach (var erro in erros)
            {
                if (erro.ErrorMessage.Equals(mensagemEsperada))
                    return true;
            }

            return false;
        }
    }
}
