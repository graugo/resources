using EJ15.Tournament.Infrastructure.Contracts.Contracts;
using EJ15.Tournament.Infrastructure.Impl.Configuration;
using EJ15.Tournament.Infrastructure.Impl.Mapper.Pokemon;
using EJ15.Tournament.Infrastructure.Impl.Models.Pokemon;
using EJ15.Tournament.Library.Models.Pokemon;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EJ15.Tournament.Infrastructure.Impl.DDBB
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly IInfrastructureConfiguration _configuration;
        private readonly ITrainerMapper _mapper;
        private readonly ILog _log;

        public TrainerRepository(IInfrastructureConfiguration configuration, ITrainerMapper mapper, ILog log)
        {
            _configuration = configuration;
            _mapper = mapper;
            _log = log;
        }

        public IEnumerable<TrainerEntity> GetTrainers()
        {
            IEnumerable<TrainerEntity> result = null;
            try
            {
                if (File.Exists(_configuration.Directory + _configuration.FileName))
                {
                    var file = File.ReadAllText(_configuration.Directory + _configuration.FileName);
                    var dto = JsonConvert.DeserializeObject<IEnumerable<TrainerDto>>(file);
                    result = _mapper.ToTrainerEntityList(dto);
                }
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }      

            return result;
        }

        public bool RemoveTrainer(TrainerEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool SetTrainer(TrainerEntity entity)
        {
            var dto = new List<TrainerDto>();
            var result = false;
            try
            {
                var path = _configuration.Directory + _configuration.FileName;
                if (!Directory.Exists(_configuration.Directory))
                    Directory.CreateDirectory(_configuration.Directory);
                if (File.Exists(path))
                {
                    var file = File.ReadAllText(path);
                    dto = JsonConvert.DeserializeObject<List<TrainerDto>>(file) ?? new List<TrainerDto>();
                    result = WriteTrainerFile(dto, entity, path);
                }
                else
                {
                    File.Create(path);
                    result = WriteTrainerFile(dto, entity, path);
                }
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
            }
            
            return result;
        }

        private bool WriteTrainerFile(List<TrainerDto> dto, TrainerEntity entity, string path) 
        {
            var trainerDto = _mapper.ToTrainerDto(entity);
            dto.Add(trainerDto);
            var trainerSerialized = JsonConvert.SerializeObject(dto);
            File.WriteAllText(path, trainerSerialized);
            return true;
        }
    }
}
