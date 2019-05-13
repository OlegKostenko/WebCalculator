using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Reposirories.Common;
using WC.BOL.DTO;
using WC.DAL.DbLayer;

namespace WC.BOL.Services
{
    public class LogDataService : IEntityService<LogDataDTO>
    {
        IGenericRepository<LogData> repository;
        readonly IMapper mapper;

        public LogDataService(IGenericRepository<LogData> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<LogData, LogDataDTO>()
                    .ForMember("FirstVariable", opt => opt.MapFrom(c => c.FirstVariable))
                    .ForMember("SecondVariable", opt => opt.MapFrom(c => c.SecondVariable))
                    .ForMember("Sign", opt => opt.MapFrom(c => c.Sign))
                    .ForMember("Summary", opt => opt.MapFrom(c => c.Summary))
                    .ForMember("LogTime", opt => opt.MapFrom(c => c.LogTime));

                cfg.CreateMap<LogDataDTO, LogData>();
            }).CreateMapper();
        }

        public IEnumerable<LogDataDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<LogDataDTO>(a));
        }

        public LogDataDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Who's known this id");
            }
            var logData = repository.Get(id.Value);
            if (logData == null)
            {
                //throw new Exception("Information not found");
                LogDataDTO log = null;
                return log;
            }
            return mapper.Map<LogDataDTO>(repository.Get(id.Value));
        }

        public IEnumerable<LogDataDTO> FindBy(Expression<Func<LogDataDTO, bool>> predicate)
        {
            Expression<Func<LogData, bool>> expr = mapper.Map<Expression<Func<LogDataDTO, bool>>, Expression<Func<LogData, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<LogDataDTO>(a));
        }

        public void AddOrUpdate(LogDataDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<LogData>(obj));
        }

        public void Delete(LogDataDTO obj)
        {
            repository.Delete(mapper.Map<LogData>(obj));
        }
    }
}
