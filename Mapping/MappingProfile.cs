using AutoMapper;
using Health.Dtos;
using Health.Dtos.AppointmentDtos;
using Health.Dtos.DoctorDtos;
using Health.Dtos.DoctorTreatmentDtos;
using Health.Dtos.PatientDtos;
using Health.Dtos.PatientTreatmentDtos;
using Health.Dtos.TreatmentDtos;
using Health.Model;

namespace Health.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Doctor, DoctorUpdateDto>();
            CreateMap<Doctor, DoctorCreateDto>();




            CreateMap<Patient, PatientDto>();
            CreateMap< PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();




            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name));
                //.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name));
            CreateMap<Appointment, AppointmentCreateDto>();
            CreateMap<Appointment, AppointmentUpdateDto>();



            CreateMap<Treatment, TreatmentDto>();
            CreateMap<Treatment, TreatmentCreateDto>();


            CreateMap<DoctorTreatments, DoctorTreatmentDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
            .ForMember(dest => dest.TreatmentName, opt => opt.MapFrom(src => src.Treatment.Name));

            // PatientTreatment -> PatientTreatmentDto
            CreateMap<PatientTreatments, PatientTreatmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.TreatmentName, opt => opt.MapFrom(src => src.Treatment.Name));
        }
    }
}
