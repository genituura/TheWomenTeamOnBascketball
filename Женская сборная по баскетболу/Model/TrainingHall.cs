//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Женская_сборная_по_баскетболу.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainingHall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
        public int ClubId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Club Club { get; set; }
    }
}
