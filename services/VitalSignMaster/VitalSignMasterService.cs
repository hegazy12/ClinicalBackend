using ElearingEnglis.DataCon.Module;
using ElearingEnglis.services.Response;
using ElearingEnglis.services.VitalSignMaster.DTOs;

namespace ElearingEnglis.services.VitalSignMaster
{
    public class VitalSignMasterService : IVitalSignMasterService
    {
        private readonly IVitalSignMasterRepo _repo;
        public VitalSignMasterService(IVitalSignMasterRepo repo)
        {
            _repo = repo;
        }

        public async Task<GeneralResponse<VitalSignMasterDto>> CreateVitalSignMasterAsync(Guid UserId, CreateVitalSignMasterDto vitalSignMasterDto)
        {
            if (UserId == Guid.Empty) {

                return new GeneralResponse<VitalSignMasterDto>
                {
                    Success=false,
                    Message="UserId is Empty",
                    Data=null
                    

                };
                    }
            if (vitalSignMasterDto == null) {
                return new GeneralResponse<VitalSignMasterDto>
                {
                    Success = false,
                    Message = "Vital sign master is null",
                    Data = null,
                    Errors =
                    {
                        { "Name", new List<string> { "Name is Empty" } }
                    }
                };
            }
            var DbEntity=Map(vitalSignMasterDto);

            try
            {
                var res = await _repo.CreateVitalSignMasterAsync(UserId, DbEntity);

                if (res == null)
                {
                    return new GeneralResponse<VitalSignMasterDto>
                    {
                        Success = false,
                        Message = "vital signal master is not added",
                        Data = null


                    };

                }

                return new GeneralResponse<VitalSignMasterDto>
                {
                    Success = true,
                    Message = "vital signal master is added successfully",
                    Data = new VitalSignMasterDto { 
                    Name= vitalSignMasterDto.Name,
                    UpdatedAt= DbEntity.UpdatedAt,
                    Id= DbEntity.Id,
                    CreatedBy= DbEntity.CreatedBy,
                    DeletedAt= DbEntity.DeletedAt,
                    IsDeleted= DbEntity.IsDeleted,
                    IsActive= DbEntity.IsActive,
                    CreatedAt= DbEntity.CreatedAt,
                    DeletedBy= DbEntity.DeletedBy,
                    IsUpdated= DbEntity.IsUpdated,
                    UpdatedBy=DbEntity.UpdatedBy,
                    
                    
                    }

                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<VitalSignMasterDto>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null


                };

            }     
        }

        public DataCon.Module.VitalSignMaster Map(CreateVitalSignMasterDto entity) {

            return new DataCon.Module.VitalSignMaster
            {
                Name = entity.Name,

            };
        }
    }
}
