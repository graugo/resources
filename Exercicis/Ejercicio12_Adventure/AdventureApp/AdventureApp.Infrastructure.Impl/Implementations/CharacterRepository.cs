using AdventureApp.Infrastructure.Contracts.Contracts;
using AdventureApp.Infrastructure.Impl.Cache;
using AdventureApp.Infrastructure.Impl.Configuration;
using AdventureApp.Infrastructure.Impl.Mappers;
using AdventureApp.Infrastructure.Impl.Models;
using AdventureApp.Library.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AdventureApp.Infrastructure.Impl.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRepoMapper _repoMapper;
        private readonly IRepoConfig _repoConfig;
        private readonly ICharacterCache _cache;
        private readonly ILog _log;
        public CharacterRepository(IRepoMapper repoMapper, 
                                   IRepoConfig repoConfig, 
                                   ICharacterCache characterCache,
                                   ILog log)
        {
            _repoConfig = repoConfig;
            _repoMapper = repoMapper;
            _cache = characterCache;
            _log = log;
        }
        public CharacterEntity CreateCharacter(CharacterEntity character)
        {
            List<CharacterDTO> list = ReadMemoryFile();
            list.Add(_repoMapper.ToCharacterDTO(character));
            string jCharacters = JsonConvert.SerializeObject(list);
            File.WriteAllText(_repoConfig.FilePath, jCharacters);
            if (_cache.Characters != null)
            {
                _cache.AddCharacter(_repoMapper.ToCharacterDTO(character));
                return character;
            }
            return null;
        }

        public CharacterEntity GetCharacter(string id)
        {
            Guid guid; ;
            try
            {
               guid = new Guid(id);
            } catch (FormatException ex)
            {
                return null;
            }
            
            CharacterDTO characterDTO = null;
            if (_cache.Characters.Any(p => p.Id == guid))
                characterDTO = _cache.Characters.FirstOrDefault(x => x.Id == guid);
            else
            {
                List<CharacterDTO> characterList = ReadMemoryFile();
                characterDTO = characterList.FirstOrDefault(x => x.Id == guid);
            }
            if (characterDTO == null)
                return null;

            return _repoMapper.ToCharacterEntity(characterDTO);
        }

        private List<CharacterDTO> ReadMemoryFile()
        {
            List<CharacterDTO> list = null;

            try
            {
                string jString = File.ReadAllText(_repoConfig.FilePath);
                list = JsonConvert.DeserializeObject<List<CharacterDTO>>(jString);
                if (list == null) list = new List<CharacterDTO>();
                _log.Info("List read properly");
            } catch(Exception ex) // todo add correct exception
            {
                list = new List<CharacterDTO>();
                // log new list created 
                _log.Error(ex.Message);
            }

            return list;
        }
    }
}
