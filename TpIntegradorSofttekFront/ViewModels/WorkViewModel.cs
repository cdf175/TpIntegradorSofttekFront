using Data.DTOs;

namespace TpIntegradorSofttekFront.ViewModels
{
    public class WorkViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProyectId { get; set; }
        public int ServiceId { get; set; }
        public int HourQuantity { get; set; }
        public decimal HourValue { get; set; }

        public static implicit operator WorkViewModel(WorkDto dto)
        {
            var viewModel = new WorkViewModel();
            viewModel.Id = dto.Id;
            viewModel.ProyectId = dto.ProyectId;
            viewModel.ServiceId = dto.ServiceId;
            viewModel.HourQuantity = dto.HourQuantity;
            viewModel.HourValue = dto.HourValue;
            return viewModel;
        }
    }
}
