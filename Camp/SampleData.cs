using Camp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp
{
    public class SampleData
    {
        public static void Initialize(CampContext context)
        {
            if (!context.Vouchers.Any())
            {
                context.Vouchers.AddRange(
                    new Voucher
                    {
                        Name = "Оздоровительная",
                        Price = 39800,
                        CountOfDay = 21,
                        Description = "Размещение в одноэтажном кирпичном стационарном корпусе с удобствами на этаже: душ, санузел, умывальник, ногомойка, в комнатах на 4-5 человек. Корпус оборудован крытой верандой, оснащенной для отрядной работы телевизором, столами, стендами, пожарной сигнализацией, питьевой водой. Кроме образовательных, психологических, культурно-досуговых и услуг по организации физической культуры и спорта, детям оказывается первая медицинская помощь, организуются консультативные приемы врачами-специалистами, проводится работа по формированию здорового образа жизни.",
                        ServiceList = "фиточай №10, кислородный коктейль №10, море, бассейн №5 (по погоде)."
                    },
                    new Voucher
                    {
                        Name = "Санаторная",
                        Price = 45580,
                        CountOfDay = 24,
                        Description = "Размещение в одноэтажном кирпичном стационарном корпусе с удобствами на этаже: душ, санузел, умывальник, ногомойка, в комнатах на 4-5 человек. Корпус оборудован крытой верандой, оснащенной для отрядной работы телевизором, столами, стендами, пожарной сигнализацией, питьевой водой. Кроме образовательных, психологических, культурно-досуговых и услуг по организации физической культуры и спорта, детям оказывается первая медицинская помощь, организуются консультативные приемы врачами-специалистами, проводится работа по формированию здорового образа жизни.",
                        ServiceList = "лечебная физкультура №5, скандинавская ходьба №5 (по погоде), кислородный коктейль №10,море,бассейн №5 (по погоде), 1 (одна) физиопроцедура по медицинским показаниям №7, соляная комната (по медицинским показаниям)."
                    });
                context.SaveChanges();
            }

            if (!context.Tours.Any())
            {
                context.AddRange(
                    new Tour
                    {
                        Name = "Первая летняя",
                        StartDate = new DateTime(2021, 05, 26),
                        CountOfPlace = 200
                    },
                    new Tour
                    {
                        Name = "Вторая летняя",
                        StartDate = new DateTime(2021, 06, 20),
                        CountOfPlace = 200
                    },
                    new Tour
                    {
                        Name = "Третья летняя",
                        StartDate = new DateTime(2021, 07, 15),
                        CountOfPlace = 200
                    });
                context.SaveChanges();
            }

            if (!context.Roles.Any() && !context.Users.Any())
            {
                //string adminRoleName = "admin";

                //string adminEmail = "admin@gmail.com";
                //string adminPassword = "123456";

                //User adminUser = new User { Email = adminEmail, Password = adminPassword };
                //Role adminRole = new Role { Name = adminRoleName };
                //adminUser.Roles.Add(adminRole);

                //context.Roles.Add(adminRole);
                //context.Users.Add(adminUser);
                //context.SaveChanges();
            }

        }
    }
}
