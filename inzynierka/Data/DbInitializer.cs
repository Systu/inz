using System;
using System.Collections.Generic;
using System.Linq;
using inzynierka.Models;
using Microsoft.EntityFrameworkCore;

namespace inzynierka.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Meals.Any())
            {
                return;
            }

            var dietList = new[]
            {
                new DietList {DietListId = Guid.NewGuid(), DietName = "Pierwsza Dieta"},
                new DietList {DietListId = Guid.NewGuid(), DietName = "Druga Dieta"},
                new DietList {DietListId = Guid.NewGuid(), DietName = "Trzecia Dieta"},
            };
            foreach (var m in dietList)
            {
                context.DietLists.Add(m);
            }

            context.SaveChanges();

            var breakfestList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jajecznica",
                    MealType = "Śniadanie",
                    Components = "jajka, masło",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Płatki na mleku",
                    MealType = "Śniadanie",
                    Components = "mleko , płatki",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        { 
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Owsianka",
                    MealType = "Śniadanie",
                    Components = "Płatki zbóż, mleko/woda",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ryż z mlekiem",
                    MealType = "Śniadanie",
                    Components = "Ryż, mleko",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jajko na twardo",
                    MealType = "Śniadanie",
                    Components = "jajka",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kanapki z szynką",
                    MealType = "Śniadanie",
                    Components = "chleb, masło, szynka",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jogurt z owocami",
                    MealType = "Śniadanie",
                    Components = "Jogurt, Owoce",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "kanpki z serem",
                    MealType = "Śniadanie",
                    Components = "chleb, masło, ser",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tosty z ogórkami",
                    MealType = "Śniadanie",
                    Components = "chleb, masło, ogórki",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
            };

            foreach (Meal m in breakfestList)
            {
                context.Meals.Add(m);
            }

            context.SaveChanges();

            var secondBrekfstList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Grillowany ananas z kokosem",
                    MealType = "Drugie śniadanie",
                    Components = " ananas, wiórki kokosowe, mięta",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Carpaccio z buraka z kruszonką z sera koziego",
                    MealType = "Drugie śniadanie",
                    Components = "ser kozi, burak, rukola, balsamico",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Grillowane warzywa z kozim serem",
                    MealType = "Drugie śniadanie",
                    Components = " cukinia, marchewka, seler, dynia, papryka, kozi ser",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto francuskie z pieczarkami i serem żółtym",
                    MealType = "Drugie śniadanie",
                    Components = "ciasto francuskie, pieczarki, ser żółty, jajko, cebula, przyprawy",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zapiekane pomidory",
                    MealType = "Drugie śniadanie",
                    Components = "pomidory, oliwa z oliwek, pestki dyni",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jabłka faszerowane bakaliami",
                    MealType = "Drugie śniadanie",
                    Components = "jabłko, migdały, żurawina, morela, suszona śliwka",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Gruszki faszerowane kaszą gryczaną z serem pleśniowym",
                    MealType = "Drugie śniadanie",
                    Components = " gruszka, ser pleśniowy, kasza gryczana, miód",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Wrap z omletem i masłem orzechowym",
                    MealType = "Drugie śniadanie",
                    Components = " jajko, orzechy ziemne, sól, banan ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Różyczki z ciasta francuskiego z jabłkiem",
                    MealType = "Drugie śniadanie",
                    Components = "ciasto francuskie, jabłko, cynamon, jajko ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Galareta z jajkiem, kukurydzą i brokułem",
                    MealType = "Drugie śniadanie",
                    Components = "bulion warzywny, agar, jajko, kukurydza, marchewka baby, brokuł ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
            };

            foreach (Meal sb in secondBrekfstList)
            {
                context.Meals.Add(sb);
            }

            context.SaveChanges();

            var dinerList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ragout cielęce z kaszą gryczaną ",
                    MealType = "Kolacja",
                    Components = "ananas, wiórki kokosowe, mięta",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Sola w sosie winnym z pomidorkami cherry z ryżem",
                    MealType = "Kolacja",
                    Components = " sola, wino białe, pomidory cherry, ryż jaśminowy, przyprawy, masło klarowane ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pad thai z makaronem ryżowym",
                    MealType = "Kolacja",
                    Components =
                        "mleko kokosowe, orzechy ziemne, makaron ryżowy, indyk, rzodkiewka, przyprawy, kiełki fasoli mung",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Burritto w tortilli",
                    MealType = "Kolacja",
                    Components = "wołowina, tortilla, fasolka czarna, papryka, kukurydza, olej kokosowy, przyprawy ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kofty z sosem tzatzyki z mixem sałat i pomidorkami z kuskus",
                    MealType = "Kolacja",
                    Components =
                        "cynamon, cielęcina, jajko, pietruszka natka, jogurt, czosnek, ogórek, przyprawy, sałata, rukola, roszponka, pomidorki koktajlowe, olej lniany ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pulpeciki rybne z sosem koperkowo- cytrynowym z ryżem",
                    MealType = "Kolacja",
                    Components = "dorsz, koperek, cytryna, ryż basmatii, jajko, przyprawy",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Chili cor carne z ryżem ",
                    MealType = "Kolacja",
                    Components =
                        "fasola czerwona, fasola czarna, fasola biała, kukurydza, papryka, habanero, ryż jaśminowy, przyprawy, olej kokosowy, pomidory ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName =
                        "Kaczka z sosem żurawinowym z kluseczkami z sokiem z pietruszki z karmelizowanymi jabłkami",
                    MealType = "Kolacja",
                    Components = "kaczka, żurawina, mąka, pietruszka natka, jajko, ziemniaki, jabłka, ksylitol",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Burgery z frytkami z batatów z lemon majo z mixem sałat i pomidorkami",
                    MealType = "Kolacja",
                    Components = "mięso wołowe, bataty, jajko, olej, cytryna, czosnke, sól, sałata, pomidorki cherry",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Lasagne ",
                    MealType = "Kolacja",
                    Components =
                        "makaron, indyk, pomidory, mąka pszenna, masło klarowane, cebula, papryka, seler naciowy, marchewka, ser żólty",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                }
            };

            foreach (Meal d in dinerList)
            {
                context.Meals.Add(d);
            }

            context.SaveChanges();

            var snackMealList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Sernik na zimno z galaretką",
                    MealType = "Podwieczorek",
                    Components = "ser chudy, agar, truskawki, ksylitol, banany",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto marchewkowe z serkiem philadelfia",
                    MealType = "Podwieczorek",
                    Components =
                        "serek philadelfia, marchewka, cynamon, kardamon, cukier trzcinowy, mąka gryczana, jajka, sok jabłkowy, nerkowce",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Szarlotka",
                    MealType = "Podwieczorek",
                    Components = "mąka gryczana, masło klarowane, jajko, jabłka, gruszki, ksylitol, cynamon ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Owoce pod gryczaną kruszonką ",
                    MealType = "Podwieczorek",
                    Components =
                        "mąka gryczana, masło klarowane, jajko, wiśnie, truskawki, mango, borówki, jabłko, gruszka, papaja",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Galaretka z owocami",
                    MealType = "Podwieczorek",
                    Components = " agar, truskawki, jagody, jabłka, wiśnie, śliwki",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pudding z tapioki",
                    MealType = "Podwieczorek",
                    Components = "tapioka, mango, granat, mleko kokosowe, wiórki kokosowe  ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Budyń z owocami",
                    MealType = "Podwieczorek",
                    Components = "mąka ziemniaczana, mleko, truskawki, cukier trzcinowy, jagody, wiśnie ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kisiel z chia i owocami",
                    MealType = "Podwieczorek",
                    Components = "gruszka, papaja, mango, mąka ziemniaczana, malina, chia",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto budyniowe z herbatnikami ",
                    MealType = "Podwieczorek",
                    Components = "ser chudy, agar, truskawki, ksylitol, banany",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pudding chia z musem z mango",
                    MealType = "Podwieczorek",
                    Components = "chia, mleko kokosowe, mango, mięta ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                }
            };

            foreach (Meal sm in snackMealList)
            {
                context.Meals.Add(sm);
            }

            context.SaveChanges();

            var supperList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z brokułów z migdałami",
                    MealType = "Kolacja",
                    Components = " brokuł, wywar warzywny, migdały, ziemniaki, marchewka",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z kalafiora z kokosem wywar warzywny",
                    MealType = "Kolacja",
                    Components = "kalafior, kurkuma, wiórki kokosowe ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z buraka z pomarańczą",
                    MealType = "Kolacja",
                    Components = "wywar warzywny, burak, marchewka, pomarańcz, mandaryna, tymianek ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z buraka z kokosem ",
                    MealType = "Kolacja",
                    Components = "wywar warzywny, burak, marchewka, wiórki kokosowe, mleko kokosowe",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa meksykańska ",
                    MealType = "Kolacja",
                    Components = "wywar warzywny, fasola, papryka, indyk, kukurydza, seler naciowy ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa gulasz",
                    MealType = "Kolacja",
                    Components = "papryka, wywar wołowy, kukurydza, wołowina, fasola czerwona, przecier pomidorowy ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tom Kha",
                    MealType = "Kolacja",
                    Components = "kafir, trawa cytrynowa, czosnek, cebula, mleko kokosowe, krewetki, wywar warzywny",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tom Yum",
                    MealType = "Kolacja",
                    Components =
                        "wywar warzywny, kafir, mleko kokosowe, pomidory, kmin rzymski, cebula, czosnek, makaron ryżowy",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[1].DietListId,
                            DietList = dietList[1]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tajski rosół z tofu",
                    MealType = "Kolacja",
                    Components =
                        "cukinia, rzodkiewka, ogórek, wywar warzywny, bulion krewetkowy, tofu, zielona herbata, makaron z tapioki",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[2].DietListId,
                            DietList = dietList[2]
                        }
                    }
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa miso z wakame",
                    MealType = "Kolacja",
                    Components =
                        " makaron z fasoli mung, wakame, bulion rybny, suszone krewetki, kafir, pasta miso, fermentowany tuńczyk ",
                    MealDietList = new List<MealDietList>
                    {
                        new MealDietList
                        {
                            DietListId = dietList[0].DietListId,
                            DietList = dietList[0]
                        }
                    }
                }
            };

            foreach (Meal s in supperList)
            {
                context.Meals.Add(s);
            }

            context.SaveChanges();

        }
    }
}