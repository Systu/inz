using System;
using System.Linq;
using System.Security.Cryptography;
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

            var brekfastList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jajecznica",
                    MealType = "Brekfast",
                    Components = "jajka, masło",
                    DietListId =dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Płatki na mleku",
                    MealType = "Brekfast",
                    Components = "mleko , płatki",
                    DietListId =dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Owsianka",
                    MealType = "Brekfast",
                    Components = "Płatki zbóż, mleko/woda",
                    DietListId =dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ryż z mlekiem",
                    MealType = "Brekfast",
                    Components = "Ryż, mleko",
                    DietListId =dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jajko na twardo",
                    MealType = "Brekfast",
                    Components = "jajka",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kanapki z szynką",
                    MealType = "Brekfast",
                    Components = "chleb, masło, szynka",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jogurt z owocami",
                    MealType = "Brekfast",
                    Components = "Jogurt, Owoce",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "kanpki z serem",
                    MealType = "Brekfast",
                    Components = "chleb, masło, ser",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tosty z ogórkami",
                    MealType = "Brekfast",
                    Components = "chleb, masło, ogórki",
                    DietListId = dietList[1].DietListId
                },
            };

            foreach (Meal m in brekfastList)
            {
                context.Meals.Add(m);
            }

            context.SaveChanges();

            var secondBrekfastList = new[]
            {
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Grillowany ananas z kokosem",
                    MealType = "Second Brekfast",
                    Components = " ananas, wiórki kokosowe, mięta",
                    DietListId = dietList[0].DietListId

                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Carpaccio z buraka z kruszonką z sera koziego",
                    MealType = "Second Brekfast",
                    Components = "ser kozi, burak, rukola, balsamico",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Grillowane warzywa z kozim serem",
                    MealType = "Second Brekfast",
                    Components = " cukinia, marchewka, seler, dynia, papryka, kozi ser",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto francuskie z pieczarkami i serem żółtym",
                    MealType = "Second Brekfast",
                    Components = "ciasto francuskie, pieczarki, ser żółty, jajko, cebula, przyprawy",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zapiekane pomidory",
                    MealType = "Second Brekfast",
                    Components = "pomidory, oliwa z oliwek, pestki dyni",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Jabłka faszerowane bakaliami",
                    MealType = "Second Brekfast",
                    Components = "jabłko, migdały, żurawina, morela, suszona śliwka",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Gruszki faszerowane kaszą gryczaną z serem pleśniowym",
                    MealType = "Second Brekfast",
                    Components = " gruszka, ser pleśniowy, kasza gryczana, miód",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Wrap z omletem i masłem orzechowym",
                    MealType = "Second Brekfast",
                    Components = " jajko, orzechy ziemne, sól, banan ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Różyczki z ciasta francuskiego z jabłkiem",
                    MealType = "Second Brekfast",
                    Components = "ciasto francuskie, jabłko, cynamon, jajko ",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Galareta z jajkiem, kukurydzą i brokułem",
                    MealType = "Second Brekfast",
                    Components = "bulion warzywny, agar, jajko, kukurydza, marchewka baby, brokuł ",
                    DietListId = dietList[0].DietListId
                },
            };

            foreach (Meal sb in secondBrekfastList)
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
                    MealType = "Diner",
                    Components = "ananas, wiórki kokosowe, mięta",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Sola w sosie winnym z pomidorkami cherry z ryżem",
                    MealType = "Diner",
                    Components = " sola, wino białe, pomidory cherry, ryż jaśminowy, przyprawy, masło klarowane ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pad thai z makaronem ryżowym",
                    MealType = "Diner",
                    Components =
                        "mleko kokosowe, orzechy ziemne, makaron ryżowy, indyk, rzodkiewka, przyprawy, kiełki fasoli mung",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Burritto w tortilli",
                    MealType = "Diner",
                    Components = "wołowina, tortilla, fasolka czarna, papryka, kukurydza, olej kokosowy, przyprawy ",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kofty z sosem tzatzyki z mixem sałat i pomidorkami z kuskus",
                    MealType = "Diner",
                    Components =
                        "cynamon, cielęcina, jajko, pietruszka natka, jogurt, czosnek, ogórek, przyprawy, sałata, rukola, roszponka, pomidorki koktajlowe, olej lniany ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pulpeciki rybne z sosem koperkowo- cytrynowym z ryżem",
                    MealType = "Diner",
                    Components = "dorsz, koperek, cytryna, ryż basmatii, jajko, przyprawy",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Chili cor carne z ryżem ",
                    MealType = "Diner",
                    Components =
                        "fasola czerwona, fasola czarna, fasola biała, kukurydza, papryka, habanero, ryż jaśminowy, przyprawy, olej kokosowy, pomidory ",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName =
                        "Kaczka z sosem żurawinowym z kluseczkami z sokiem z pietruszki z karmelizowanymi jabłkami",
                    MealType = "Diner",
                    Components = "kaczka, żurawina, mąka, pietruszka natka, jajko, ziemniaki, jabłka, ksylitol",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Burgery z frytkami z batatów z lemon majo z mixem sałat i pomidorkami",
                    MealType = "Diner",
                    Components = "mięso wołowe, bataty, jajko, olej, cytryna, czosnke, sól, sałata, pomidorki cherry",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Lasagne ",
                    MealType = "Diner",
                    Components =
                        "makaron, indyk, pomidory, mąka pszenna, masło klarowane, cebula, papryka, seler naciowy, marchewka, ser żólty",
                    DietListId = dietList[0].DietListId
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
                    MealType = "Snack Meal",
                    Components = "ser chudy, agar, truskawki, ksylitol, banany",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto marchewkowe z serkiem philadelfia",
                    MealType = "Snack Meal",
                    Components =
                        "serek philadelfia, marchewka, cynamon, kardamon, cukier trzcinowy, mąka gryczana, jajka, sok jabłkowy, nerkowce",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Szarlotka",
                    MealType = "Snack Meal",
                    Components = "mąka gryczana, masło klarowane, jajko, jabłka, gruszki, ksylitol, cynamon ",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Owoce pod gryczaną kruszonką ",
                    MealType = "Snack Meal",
                    Components =
                        "mąka gryczana, masło klarowane, jajko, wiśnie, truskawki, mango, borówki, jabłko, gruszka, papaja",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Galaretka z owocami",
                    MealType = "Snack Meal",
                    Components = " agar, truskawki, jagody, jabłka, wiśnie, śliwki",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pudding z tapioki",
                    MealType = "Snack Meal",
                    Components = "tapioka, mango, granat, mleko kokosowe, wiórki kokosowe  ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Budyń z owocami",
                    MealType = "Snack Meal",
                    Components = "mąka ziemniaczana, mleko, truskawki, cukier trzcinowy, jagody, wiśnie ",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Kisiel z chia i owocami",
                    MealType = "Snack Meal",
                    Components = "gruszka, papaja, mango, mąka ziemniaczana, malina, chia",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Ciasto budyniowe z herbatnikami ",
                    MealType = "Snack Meal",
                    Components = "ser chudy, agar, truskawki, ksylitol, banany",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Pudding chia z musem z mango",
                    MealType = "Snack Meal",
                    Components = "chia, mleko kokosowe, mango, mięta ",
                    DietListId = dietList[2].DietListId
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
                    MealType = "Supper",
                    Components = " brokuł, wywar warzywny, migdały, ziemniaki, marchewka",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z kalafiora z kokosem wywar warzywny",
                    MealType = "Supper",
                    Components = "kalafior, kurkuma, wiórki kokosowe ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z buraka z pomarańczą",
                    MealType = "Supper",
                    Components = "wywar warzywny, burak, marchewka, pomarańcz, mandaryna, tymianek ",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Krem z buraka z kokosem ",
                    MealType = "Supper",
                    Components = "wywar warzywny, burak, marchewka, wiórki kokosowe, mleko kokosowe",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa meksykańska ",
                    MealType = "Supper",
                    Components = "wywar warzywny, fasola, papryka, indyk, kukurydza, seler naciowy ",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa gulasz",
                    MealType = "Supper",
                    Components = "papryka, wywar wołowy, kukurydza, wołowina, fasola czerwona, przecier pomidorowy ",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tom Kha",
                    MealType = "Supper",
                    Components = "kafir, trawa cytrynowa, czosnek, cebula, mleko kokosowe, krewetki, wywar warzywny",
                    DietListId = dietList[0].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tom Yum",
                    MealType = "Supper",
                    Components =
                        "wywar warzywny, kafir, mleko kokosowe, pomidory, kmin rzymski, cebula, czosnek, makaron ryżowy",
                    DietListId = dietList[1].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Tajski rosół z tofu",
                    MealType = "Supper",
                    Components =
                        "cukinia, rzodkiewka, ogórek, wywar warzywny, bulion krewetkowy, tofu, zielona herbata, makaron z tapioki",
                    DietListId = dietList[2].DietListId
                },
                new Meal
                {
                    MealId = Guid.NewGuid(),
                    MealName = "Zupa miso z wakame",
                    MealType = "Supper",
                    Components =
                        " makaron z fasoli mung, wakame, bulion rybny, suszone krewetki, kafir, pasta miso, fermentowany tuńczyk ",
                    DietListId = dietList[0].DietListId
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