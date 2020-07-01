using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using ChanceNET;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RomanNumerals;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Middleware
{
    public static class SeedDatabase
    {
        public static async Task Seed(this IDefaultDbContext context, IConfiguration configuration, CancellationToken cancellationToken)
        {
            var seedsMultiplier = configuration.GetSection("AppSettings").GetValue<int>("SeedsMultiplier");
            if (seedsMultiplier == 0)
            {
                Log.Debug("Seeds multiplier set to 0, no seeds generated!");
                return;
            }

            await context.SeedSamples(seedsMultiplier * 10, cancellationToken);
            await context.SeedItems(cancellationToken);
            await context.SeedProfessions(cancellationToken);
            await context.SeedVillagers(cancellationToken);
        }

        internal static async Task SeedSamples(this IDefaultDbContext context, int inserts, CancellationToken cancellationToken)
        {
            var totalSamples = await context.Samples.CountAsync(cancellationToken);

            while (totalSamples < inserts)
            {
                int saveCounter = 0;

                for (int i = totalSamples; i < inserts; i++)
                {
                    Chance chance = new Chance(Guid.NewGuid().ToString());

                    var sample = new Sample
                    {
                        Description = chance.Paragraph(3)
                    };

                    await context.Samples.AddAsync(sample, cancellationToken);

                    saveCounter++;

                    if (saveCounter == 100)
                    {
                        Log.Debug($"Saving {saveCounter} samples.");
                        await context.SaveChangesAsync(cancellationToken);
                        saveCounter = 0;
                    }
                }

                if (saveCounter > 0)
                {
                    Log.Debug($"Saving {saveCounter} samples.");
                    await context.SaveChangesAsync(cancellationToken);
                    saveCounter = 0;
                }

                totalSamples = await context.Samples.CountAsync(cancellationToken);

                Log.Debug($"{totalSamples} samples alread saved.");
            }

            Log.Debug("Samples data seed completed.");
        }
        internal static async Task SeedProfessions(this IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var total = await context.Professions.CountAsync(cancellationToken);

            if (total > 0) return;

            var professions = new List<Profession>();

            professions.Add(CreateUnemployed(context));
            professions.Add(await CreateFarmerAsync(context, cancellationToken));
            professions.Add(await CreateFishermanAsync(context, cancellationToken));
            professions.Add(await CreateShepherdAsync(context, cancellationToken));
            professions.Add(CreateFletcher(context));
            professions.Add(CreateCleric(context));
            professions.Add(CreateWeaponsmith(context));
            professions.Add(CreateArmorer(context));
            professions.Add(CreateToolsmith(context));
            professions.Add(CreateLibrarian(context));
            professions.Add(CreateCartographer(context));
            professions.Add(CreateLeatherworker(context));
            professions.Add(CreateButcher(context));
            professions.Add(CreateMason(context));
            professions.Add(CreateNitwit(context));

            foreach (var profession in professions.OrderBy(x => x.Order))
            {
                await context.Professions.AddAsync(profession, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            total = await context.Professions.CountAsync(cancellationToken);

            Log.Debug($"{total} professions alread saved.");

            Log.Debug("Professions data seed completed.");
        }
        internal static async Task SeedVillagers(this IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var total = await context.Villagers.CountAsync(cancellationToken);

            if (total > 0) return;

            var villagers = new List<Villager>();

            var librarian = await context.Professions.Where(x => x.Name == "Librarian").SingleOrDefaultAsync(cancellationToken);

            villagers.Add(new Villager { Name = "Loja 01", Description = "Loja 01", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 02", Description = "Loja 02", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 03", Description = "Loja 03", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 04", Description = "Loja 04", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 05", Description = "Loja 05", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 06", Description = "Loja 06", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 07", Description = "Loja 07", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 08", Description = "Loja 08", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 09", Description = "Loja 09", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 10", Description = "Loja 10", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 11", Description = "Loja 11", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 12", Description = "Loja 12", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 13", Description = "Loja 13", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 14", Description = "Loja 14", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 15", Description = "Loja 15", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 16", Description = "Loja 16", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 17", Description = "Loja 17", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 18", Description = "Loja 18", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 19", Description = "Loja 19", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 20", Description = "Loja 20", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 21", Description = "Loja 21", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 22", Description = "Loja 22", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 23", Description = "Loja 23", ProfessionID = librarian.ProfessionID });
            villagers.Add(new Villager { Name = "Loja 24", Description = "Loja 24", ProfessionID = librarian.ProfessionID });

            foreach (var villager in villagers)
            {
                await context.Villagers.AddAsync(villager, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            total = await context.Villagers.CountAsync(cancellationToken);

            Log.Debug($"{total} villagers alread saved.");

            Log.Debug("Villager data seed completed.");
        }
        internal static async Task SeedItems(this IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var total = await context.Items.CountAsync(cancellationToken);

            if (total > 0) return;

            var urlBase = "https://minecraft.gamepedia.com";

            var urlBlocksFolder = "block";
            var urlItemsFolder = "item";
            var urlEnchantedBooksFolder = "Enchanting";

            var blocks = await GetBlocks(urlBase, urlBlocksFolder);
            var items = await GetItems(urlBase, urlItemsFolder);

            var enchanted_book = items.Where(x => x.Name.ToLower().Contains("enchanted book")).SingleOrDefault();

            var books = await GetEnchantedBooks(enchanted_book, urlBase, urlEnchantedBooksFolder);

            foreach (var block in blocks)
            {
                if (!await context.Items.AnyAsync(x => x.Name.ToLower().Equals(block.Name.ToLower()), cancellationToken))
                {
                    await context.Items.AddAsync(block, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }

            foreach (var item in items)
            {
                if (!await context.Items.AnyAsync(x => x.Name.ToLower().Equals(item.Name.ToLower()), cancellationToken))
                {
                    await context.Items.AddAsync(item, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }

            foreach (var book in books)
            {
                if (!await context.Items.AnyAsync(x => x.Name.ToLower().Equals(book.Name.ToLower()), cancellationToken))
                {
                    await context.Items.AddAsync(book, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }

            total = await context.Items.CountAsync(cancellationToken);

            Log.Debug($"{total} items alread saved.");

            Log.Debug("Item data seed completed.");
        }
        private static async Task<List<Item>> GetBlocks(string urlBase, string urlFolder)
        {
            var url = $"{urlBase}/{urlFolder}";
            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var nodes = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetClasses().Any(c => c.Equals("collapsible")))
                .ToList()
                .SingleOrDefault()
                .Descendants("li")
                .ToList();
            int count = 0;

            var blocks = new List<Item>();
            foreach (var node in nodes)
            {
                var block = new Item();
                block.Name = node.InnerText.Trim();

                var img = node.Descendants("img").SingleOrDefault();
                if (img != null)
                {
                    block.Image = img.OuterHtml;
                }

                var listA = node.Descendants("a").ToList();
                var a = listA.Count == 1
                    ? listA.SingleOrDefault()
                    : listA.Count == 0
                        ? null
                        : listA.Where(a => a.GetClasses().Any(c => c.Equals("mw-redirect"))).SingleOrDefault();
                if (a != null)
                {
                    var attributeValue = a.GetAttributeValue("href", string.Empty);
                    block.Description = urlBase + attributeValue;
                }
                count++;

                blocks.Add(block);
            }

            return blocks;
        }
        private static async Task<List<Item>> GetItems(string urlBase, string urlFolder)
        {
            var url = $"{urlBase}/{urlFolder}";
            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetClasses().Any(c => c.Equals("div-col")))
                .ToList();

            var nodes = new List<HtmlNode>();

            for (int i = 0; i < (divs.Count - 1); i++)
            {
                nodes.AddRange(divs[i].Descendants("li").ToList());
            }

            int count = 0;

            var items = new List<Item>();
            foreach (var node in nodes)
            {
                var item = new Item();
                item.Name = node.InnerText.Trim();

                var span = node.Descendants("span").Where(s => s.GetClasses().Any(c => c.Equals("sprite"))).SingleOrDefault();
                if (span != null)
                {
                    item.Image = span.OuterHtml;
                }


                var listA = node.Descendants("a").ToList();
                var a = listA.Count == 1
                    ? listA.SingleOrDefault()
                    : listA.Count == 0
                        ? null
                        : listA.Where(a => a.GetClasses().Any(c => c.Equals("mw-redirect"))).SingleOrDefault();
                if (a != null)
                {
                    var attributeValue = a.GetAttributeValue("href", string.Empty);
                    item.Description = urlBase + attributeValue;
                }
                count++;

                items.Add(item);
            }

            return items;
        }
        private static async Task<List<Item>> GetEnchantedBooks(Item enchantedBook, string urlBase, string urlEnchantedBooksFolder)
        {
            var url = $"{urlBase}/{urlEnchantedBooksFolder}";
            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var tables = htmlDocument.DocumentNode.Descendants("table")
                .Where(node =>
                    node.GetClasses().Any(c => c.Equals("wikitable"))
                    && node.GetAttributeValue("data-description", string.Empty).Contains("Enchantments")
                )
                .ToList();

            var nodes = new List<HtmlNode>();

            nodes.AddRange(
                tables
                    .SelectMany(t => t.Descendants("tbody"))
                    .SelectMany(tbody => tbody.Descendants("td"))
                    .Where(td => td.Descendants("a").ToList().Any())
                    .ToList()
            );

            var enchanted_books = new List<Item>();
            foreach (var node in nodes)
            {
                var name_parts = node.InnerText.Split('(');
                var enchantName = name_parts[0].Trim();
                var enchantLevelMax = name_parts[1].Replace(")", string.Empty).Replace("\n", string.Empty).Trim();
                var roman = new RomanNumeral(enchantLevelMax);
                for (int i = 1; i <= roman.ToInt(); i++)
                {
                    var enchanted_book = new Item();
                    enchanted_book.Image = enchantedBook.Image;
                    var level = new RomanNumeral(i);
                    enchanted_book.Name = $"{enchantedBook.Name}: {enchantName} {level}";

                    var attributeValue = node.Descendants("a").SingleOrDefault().GetAttributeValue("href", string.Empty);
                    enchanted_book.Description = urlBase + attributeValue;

                    enchanted_books.Add(enchanted_book);
                }
            }

            return enchanted_books;
        }

        #region Create profession
        #region Create profession unemployed
        private static Profession CreateUnemployed(IDefaultDbContext context)
        {
            var unemployed = new Profession
            {
                Order = 1,
                Name = "Unemployed",
                Default = true,
                Description = "No trades until employed."
            };

            return unemployed;
        }
        #endregion

        #region Create profession farmer
        private static async Task<Profession> CreateFarmerAsync(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var farmer = new Profession
            {
                Order = 2,
                Name = "Farmer",
                Default = false,
                Description = "Trades crops and natural foods."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bread");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "pumpkin pie");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "apple");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "cookie");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "suspicious stew");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "cake");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "golden carrot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "glistering melon slice");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "wheat");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "potato");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "carrot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "beetroot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "pumpkin");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "melon");

            professionItems.ForEach(professionItem => farmer.ProfessionItems.Add(professionItem));

            return farmer;
        }
        #endregion

        #region Create profession fisherman
        private static async Task<Profession> CreateFishermanAsync(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken)
        {
            var fisherman = new Profession
            {
                Order = 3,
                Name = "Fisherman",
                Default = false,
                Description = "Trades campfires and fishing items."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bucket of cod");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "cooked cod");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "campfire");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "cooked salmon");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted fishing rod");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "string");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coal");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw cod");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw salmon");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "tropical fish");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "pufferfish");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "boat", false);

            professionItems.ForEach(professionItem => fisherman.ProfessionItems.Add(professionItem));

            return fisherman;
        }
        #endregion

        #region Create profession shepherd
        private static async Task<Profession> CreateShepherdAsync(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var shepherd = new Profession
            {
                Order = 4,
                Name = "Shepherd",
                Default = false,
                Description = "Trades shears, wool, dyes, paintings and beds."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "shears");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "wool", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "carpet", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, " bed", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "banner", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "painting");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "dye", false);

            professionItems.ForEach(professionItem => shepherd.ProfessionItems.Add(professionItem));

            return shepherd;
        }
        #endregion

        #region Create profession fletcher
        private static Profession CreateFletcher(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var fletcher = new Profession
            {
                Order = 5,
                Name = "Fletcher",
                Default = false,
                Description = "Trades bows, crossbows, all types of arrows (except luck) and archery ingredients."
            };

            return fletcher;
        }
        #endregion

        #region Create profession cleric
        private static Profession CreateCleric(IDefaultDbContext context)
        {
            var cleric = new Profession
            {
                Order = 6,
                Name = "Cleric",
                Default = false,
                Description = "Trades magic items like ender pearls, redstone dust, and enchanting or potions ingredients."
            };

            return cleric;
        }
        #endregion

        #region Create profession weaponsmith
        private static Profession CreateWeaponsmith(IDefaultDbContext context)
        {
            var weaponsmith = new Profession
            {
                Order = 7,
                Name = "Weaponsmith",
                Default = false,
                Description = "Trades minerals, bells and enchanted melee weapons."
            };

            return weaponsmith;
        }
        #endregion

        #region Create profession armorer
        private static Profession CreateArmorer(IDefaultDbContext context)
        {
            var armorer = new Profession
            {
                Order = 8,
                Name = "Armorer",
                Default = false,
                Description = "Trades foundry items and sells chain, iron and enchanted diamond armor tiers."
            };

            return armorer;
        }
        #endregion

        #region Create profession toolsmith
        private static Profession CreateToolsmith(IDefaultDbContext context)
        {
            var toolsmith = new Profession
            {
                Order = 9,
                Name = "Toolsmith",
                Default = false,
                Description = "Trades minerals, bells and harvest tools."
            };

            return toolsmith;
        }
        #endregion

        #region Create profession librarian
        private static Profession CreateLibrarian(IDefaultDbContext context)
        {
            var librarian = new Profession
            {
                Order = 10,
                Name = "Librarian",
                Default = false,
                Description = "Trades enchanted books, clocks, compasses, name tags, glass, ink sacs, lanterns, and book and quills."
            };

            return librarian;
        }
        #endregion

        #region Create profession cartographer
        private static Profession CreateCartographer(IDefaultDbContext context)
        {
            var cartographer = new Profession
            {
                Order = 11,
                Name = "Cartographer",
                Default = false,
                Description = "Trades banners, compasses, banner patterns, papers and various maps, including explorer maps."
            };

            return cartographer;
        }
        #endregion

        #region Create profession leatherworker
        private static Profession CreateLeatherworker(IDefaultDbContext context)
        {
            var leatherwork = new Profession
            {
                Order = 12,
                Name = "Leatherworker",
                Default = false,
                Description = "Trades scutes, rabbit hide, and leather-related items."
            };

            return leatherwork;
        }
        #endregion

        #region Create profession butcher
        private static Profession CreateButcher(IDefaultDbContext context)
        {
            var butcher = new Profession
            {
                Order = 13,
                Name = "Butcher",
                Default = false,
                Description = "Trades meats, sweet berries, rabbit stew, and dried kelp blocks."
            };

            return butcher;
        }
        #endregion

        #region Create profession mason
        private static Profession CreateMason(IDefaultDbContext context)
        {
            var mason = new Profession
            {
                Order = 14,
                Name = "Mason",
                Default = false,
                Description = "Trades polished stones, terracotta, clay, glazed terracotta and quartz."
            };

            return mason;
        }
        #endregion

        #region Create profession nitwit
        private static Profession CreateNitwit(IDefaultDbContext context)
        {
            var nitwit = new Profession
            {
                Order = 15,
                Name = "Nitwit",
                Default = false,
                Description = "No trades"
            };

            return nitwit;
        }
        #endregion
        private static async Task CreateProfessionItemAsync(IDefaultDbContext context, CancellationToken cancellationToken, List<ProfessionItem> professionItems, string itemName, bool equals = true)
        {
            var items = await context.Items.Where(x =>
                (equals && x.Name.ToLower().Equals(itemName.ToLower()))
                || (!equals && x.Name.ToLower().Contains(itemName.ToLower()))
            ).ToListAsync(cancellationToken);

            if (items != null && items.Count > 0)
            {
                items.ForEach(item => professionItems.Add(new ProfessionItem { ItemID = item.ItemID }));
            }

        }
        #endregion
    }
}
