using AutoMapper;
using DesafioBoltons.Domain.DTOs;
using DesafioBoltons.Domain.Entities;
using DesafioBoltons.Domain.Interfaces;
using DesafioBoltons.Service.Utilitarios;
using DesafioBoltons.Service.Validators;
using FluentValidation;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace DesafioBoltons.Service.Services
{
    public class NFeService : INFeService
    {
        private readonly INFeRepository _repositorio;
        private readonly IMapper _mapper;

        #region Ctor

        public NFeService(INFeRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        #endregion

        public async Task<NFeDTO> BuscarTodos(BuscarNFeDTO model)
        {
            //Verifica se há registro no BD, se não existir, insere
            if (await _repositorio.BuscarPorId(2) == null) await IntegracaoAPIArquivei();

            var nfe = await _repositorio.BuscarTodos(model.access_key);

            return nfe == null ? null : _mapper.Map<NFeDTO>(nfe);
        }

        public void Adicionar(AdicionarNFeDTO model)
        {
            foreach (var item in model.data)
            {
                NFeEntity nfe = _mapper.Map<NFeEntity>(item);

                VerificarInconsistencias(nfe, new NFeValidator());
                var r = _repositorio.Adicionar(nfe);
            }
        }

        #region Métodos Utilitários

        private async Task<bool> IntegracaoAPIArquivei()
        {
            var client = new RestClient($"https://sandbox-api.arquivei.com.br/v1/nfe/received");
            var request = new RestRequest(Method.GET);

            request.AddHeader("x-api-id", IntegracaoArquivei.id);
            request.AddHeader("x-api-key", IntegracaoArquivei.chave);
            request.AddHeader("Content-Type", IntegracaoArquivei.midia);

            IRestResponse response = await client.ExecuteAsync(request);

            if (!response.StatusDescription.Equals("OK"))
                throw new Exception("Ocorreu um erro ao realizar a integração com a API Arquivei, tente novamente.");

            Adicionar(JsonConvert.DeserializeObject<AdicionarNFeDTO>(response.Content));

            return true;
        }

        #endregion

        #region Validações

        private void VerificarInconsistencias(NFeEntity obj, NFeValidator validator)
        {
            validator.ValidateAndThrow(obj);
        }

        #endregion
    }
}
