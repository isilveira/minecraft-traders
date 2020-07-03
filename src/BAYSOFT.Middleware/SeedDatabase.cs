using BAYSOFT.Core.Domain.Entities.Defaults;
using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using ChanceNET;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelWrapper.Extensions.Select;
using RomanNumerals;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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
            professions.Add(await CreateFletcherAsync(context, cancellationToken));
            professions.Add(await CreateClericAsync(context, cancellationToken));
            professions.Add(await CreateWeaponsmithAsync(context, cancellationToken));
            professions.Add(await CreateArmorerAsync(context, cancellationToken));
            professions.Add(await CreateToolsmithAsync(context, cancellationToken));
            professions.Add(await CreateLibrarianAsync(context, cancellationToken));
            professions.Add(await CreateCartographerAsync(context, cancellationToken));
            professions.Add(await CreateLeatherworkerAsync(context, cancellationToken));
            professions.Add(await CreateButcherAsync(context, cancellationToken));
            professions.Add(await CreateMasonAsync(context, cancellationToken));
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

            var librarian = await context.Professions
                .Include(x => x.ProfessionItems).ThenInclude(x => x.Item)
                .Where(x => x.Name.ToLower().Equals("librarian"))
                .SingleOrDefaultAsync(cancellationToken);

            CreateVillagerLoja01(villagers, librarian);
            CreateVillagerLoja02(villagers, librarian);
            CreateVillagerLoja03(villagers, librarian);
            CreateVillagerLoja04(villagers, librarian);
            CreateVillagerLoja05(villagers, librarian);
            CreateVillagerLoja06(villagers, librarian);
            CreateVillagerLoja07(villagers, librarian);
            CreateVillagerLoja08(villagers, librarian);
            CreateVillagerLoja09(villagers, librarian);
            CreateVillagerLoja10(villagers, librarian);
            CreateVillagerLoja11(villagers, librarian);
            CreateVillagerLoja12(villagers, librarian);
            CreateVillagerLoja13(villagers, librarian);
            CreateVillagerLoja14(villagers, librarian);
            CreateVillagerLoja15(villagers, librarian);
            CreateVillagerLoja16(villagers, librarian);
            CreateVillagerLoja17(villagers, librarian);
            CreateVillagerLoja18(villagers, librarian);
            CreateVillagerLoja19(villagers, librarian);
            CreateVillagerLoja20(villagers, librarian);
            CreateVillagerLoja21(villagers, librarian);
            CreateVillagerLoja22(villagers, librarian);
            CreateVillagerLoja23(villagers, librarian);
            CreateVillagerLoja24(villagers, librarian);


            foreach (var villager in villagers)
            {
                await context.Villagers.AddAsync(villager, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);
            }

            total = await context.Villagers.CountAsync(cancellationToken);

            Log.Debug($"{total} villagers alread saved.");

            Log.Debug("Villager data seed completed.");
        }
        private static void CreateVillagerLoja01(List<Villager> villagers, Profession librarian)
        {
            var loja01 = new Villager
            {
                Name = "Loja 01",
                Description = "Loja 01",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var looting_ii = GetItemEnchantedBookLootingII(librarian);
            var fortune_i = GetItemEnchantedBookFortuneI(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var protection_i = GetItemEnchantedBookProtectionI(librarian);
            var name_tag = GetItemNameTag(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept { Amount = 24, ItemID = paper.ItemID });
            nc1.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja01.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv1.Accepts.Add(new Accept { Amount = 23, ItemID = emerald.ItemID });
            nv1.Offers.Add(new Offer { Amount = 1, ItemID = looting_ii.ItemID });
            loja01.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept { Amount = 4, ItemID = book.ItemID });
            nc2.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja01.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept { Amount = 18, ItemID = emerald.ItemID });
            nv2.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv2.Offers.Add(new Offer { Amount = 1, ItemID = fortune_i.ItemID });
            loja01.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept { Amount = 5, ItemID = ink_sac.ItemID });
            nc3.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja01.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept { Amount = 1, ItemID = emerald.ItemID });
            nv3.Offers.Add(new Offer { Amount = 4, ItemID = glass.ItemID });
            loja01.Trades.Add(nv3);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept { Amount = 1, ItemID = book_and_quill.ItemID });
            nc4.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja01.Trades.Add(nc4);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept { Amount = 9, ItemID = emerald.ItemID });
            nv4.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv4.Offers.Add(new Offer { Amount = 1, ItemID = protection_i.ItemID });
            loja01.Trades.Add(nv4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept { Amount = 20, ItemID = emerald.ItemID });
            nc5.Offers.Add(new Offer { Amount = 1, ItemID = name_tag.ItemID });
            loja01.Trades.Add(nc5);

            villagers.Add(loja01);
        }
        private static void CreateVillagerLoja02(List<Villager> villagers, Profession librarian)
        {
            var loja02 = new Villager
            {
                Name = "Loja 02",
                Description = "Loja 02",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var lantern = GetItemLantern(librarian);
            var protection_ii = GetItemEnchantedBookProtectionII(librarian);
            var sharpness_iii = GetItemEnchantedBookSharpnessIII(librarian);
            var thorns_iii = GetItemEnchantedBookThornsIII(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept { Amount = 24, ItemID = paper.ItemID });
            nc1.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja02.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept { Amount = 20, ItemID = emerald.ItemID });
            nv1.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv1.Offers.Add(new Offer { Amount = 1, ItemID = protection_ii.ItemID });
            loja02.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept { Amount = 4, ItemID = book.ItemID });
            nc2.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja02.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept { Amount = 1, ItemID = emerald.ItemID });
            nv2.Offers.Add(new Offer { Amount = 1, ItemID = lantern.ItemID });
            loja02.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept { Amount = 5, ItemID = ink_sac.ItemID });
            nc3.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja02.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept { Amount = 44, ItemID = emerald.ItemID });
            nv3.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv3.Offers.Add(new Offer { Amount = 1, ItemID = sharpness_iii.ItemID });
            loja02.Trades.Add(nv3);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept { Amount = 1, ItemID = book_and_quill.ItemID });
            nc4.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja02.Trades.Add(nc4);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept { Amount = 44, ItemID = emerald.ItemID });
            nv4.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv4.Offers.Add(new Offer { Amount = 1, ItemID = thorns_iii.ItemID });
            loja02.Trades.Add(nv4);

            var nv5 = new Trade();
            nv5.Accepts.Add(new Accept { Amount = 20, ItemID = emerald.ItemID });
            nv5.Offers.Add(new Offer { Amount = 1, ItemID = name_tag.ItemID });
            loja02.Trades.Add(nv5);

            villagers.Add(loja02);
        }
        private static void CreateVillagerLoja03(List<Villager> villagers, Profession librarian)
        {
            var loja03 = new Villager
            {
                Name = "Loja 03",
                Description = "Loja 03",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var inc_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var flame_i = GetItemEnchantedBookFlameI(librarian);
            var mending_i = GetItemEnchantedBookMendingI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept { Amount = 24, ItemID = paper.ItemID });
            nc1.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja03.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept { Amount = 11, ItemID = emerald.ItemID });
            nv1.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv1.Offers.Add(new Offer { Amount = 1, ItemID = flame_i.ItemID });
            loja03.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept { Amount = 4, ItemID = book.ItemID });
            nc2.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja03.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept { Amount = 32, ItemID = emerald.ItemID });
            nv2.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv2.Offers.Add(new Offer { Amount = 1, ItemID = mending_i.ItemID });
            loja03.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept { Amount = 5, ItemID = inc_sac.ItemID });
            nc3.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja03.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept { Amount = 1, ItemID = emerald.ItemID });
            nv3.Offers.Add(new Offer { Amount = 4, ItemID = glass.ItemID });
            loja03.Trades.Add(nv3);

            //var nc4 = new Trade();
            //nc4.Accepts.Add(new Accept { });
            //nc4.Offers.Add(new Offer { });
            //loja03.Trades.Add(nc4);

            //var nv4 = new Trade();
            //nv4.Accepts.Add(new Accept { });
            //nv4.Offers.Add(new Offer { });
            //loja03.Trades.Add(nv4);

            //var nv5 = new Trade();
            //nv5.Accepts.Add(new Accept { });
            //nv5.Offers.Add(new Offer { });
            //loja03.Trades.Add(nv5);

            villagers.Add(loja03);
        }
        private static void CreateVillagerLoja04(List<Villager> villagers, Profession librarian)
        {
            var loja04 = new Villager
            {
                Name = "Loja 04",
                Description = "Loja 04",
                ProfessionID = librarian.ProfessionID
            };



            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var compass = GetItemCompass(librarian);
            var name_tag = GetItemNameTag(librarian);
            var respiration_i = GetItemEnchantedBookRespirationII(librarian);
            var respiration_iii = GetItemEnchantedBookRespirationIII(librarian);
            var blast_protection_iv = GetItemEnchantedBookBlastProtectionIV(librarian);
            var depth_strider_i = GetItemEnchantedBookDepthStriderI(librarian);
            var depth_strider_ii = GetItemEnchantedBookDepthStriderII(librarian);
            var protection_iv = GetItemEnchantedBookProtectionIV(librarian);
            var fire_aspect_i = GetItemEnchantedBookFireAspectI(librarian);
            var feather_falling_i = GetItemEnchantedBookFeatherFallingI(librarian);
            var feather_falling_ii = GetItemEnchantedBookFeatherFallingII(librarian);
            var feather_falling_iii = GetItemEnchantedBookFeatherFallingIII(librarian);
            var silk_touch_i = GetItemEnchantedBookSilkTouchI(librarian);
            var fortune_ii = GetItemEnchantedBookFortuneII(librarian);
            var fire_protection_i = GetItemEnchantedBookFireProtectionI(librarian);
            var fire_protection_ii = GetItemEnchantedBookFireProtectionII(librarian);
            var fire_protection_iii = GetItemEnchantedBookFireProtectionIII(librarian);
            var fire_protection_iv = GetItemEnchantedBookFireProtectionIV(librarian);
            var looting_i = GetItemEnchantedBookLootingI(librarian);
            var looting_ii = GetItemEnchantedBookLootingII(librarian);
            var looting_iii = GetItemEnchantedBookLootingIII(librarian);
            var thorns_i = GetItemEnchantedBookThornsI(librarian);
            var thorns_ii = GetItemEnchantedBookThornsII(librarian);
            var thorns_iii = GetItemEnchantedBookThornsIII(librarian);
            var sharpness_i = GetItemEnchantedBookSharpnessI(librarian);
            var sharpness_ii = GetItemEnchantedBookSharpnessII(librarian);
            var sharpness_iii = GetItemEnchantedBookSharpnessIII(librarian);
            var sharpness_iv = GetItemEnchantedBookSharpnessIV(librarian);
            var quick_charge_i = GetItemEnchantedBookQuickChargeI(librarian);
            var quick_charge_ii = GetItemEnchantedBookQuickChargeII(librarian);
            var quick_charge_iii = GetItemEnchantedBookQuickChargeIII(librarian);
            var punch_i = GetItemEnchantedBookPunchI(librarian);
            var punch_ii = GetItemEnchantedBookPunchII(librarian);
            var piercing_i = GetItemEnchantedBookPiercingI(librarian);
            var piercing_ii = GetItemEnchantedBookPiercingII(librarian);
            var piercing_iii = GetItemEnchantedBookPiercingIII(librarian);
            var piercing_iv = GetItemEnchantedBookPiercingIV(librarian);
            var luck_of_the_sea_i = GetItemEnchantedBookLuckOfTheSeaI(librarian);
            var luck_of_the_sea_ii = GetItemEnchantedBookLuckOfTheSeaII(librarian);
            var infinity_i = GetItemEnchantedBookInfinityI(librarian);
            var multishot_i = GetItemEnchantedBookMultishotI(librarian);
            var aqua_affinity_i = GetItemEnchantedBookAquaAffinityI(librarian);

            villagers.Add(loja04);
        }
        private static void CreateVillagerLoja05(List<Villager> villagers, Profession librarian)
        {
            var loja05 = new Villager
            {
                Name = "Loja 05",
                Description = "Loja 05",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var lantern = GetItemLantern(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var power_iv = GetItemEnchantedBookPowerIV(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept { Amount = 24, ItemID = paper.ItemID });
            nc1.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja05.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept { Amount = 6, ItemID = emerald.ItemID });
            nv1.Offers.Add(new Offer { Amount = 1, ItemID = bookshelf.ItemID });
            loja05.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept { Amount = 4, ItemID = book.ItemID });
            nc2.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja05.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept { Amount = 1, ItemID = emerald.ItemID });
            nv2.Offers.Add(new Offer { Amount = 1, ItemID = lantern.ItemID });
            loja05.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept { Amount = 5, ItemID = ink_sac.ItemID });
            nc3.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja05.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept { Amount = 21, ItemID = emerald.ItemID });
            nv3.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv3.Offers.Add(new Offer { Amount = 1, ItemID = power_iv.ItemID });
            loja05.Trades.Add(nv3);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept { Amount = 1, ItemID = book_and_quill.ItemID });
            nc4.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja05.Trades.Add(nc4);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept { Amount = 5, ItemID = emerald.ItemID });
            nv4.Offers.Add(new Offer { Amount = 1, ItemID = clock.ItemID });
            loja05.Trades.Add(nv4);

            var nv5 = new Trade();
            nv5.Accepts.Add(new Accept { Amount = 20, ItemID = emerald.ItemID });
            nv5.Offers.Add(new Offer { Amount = 1, ItemID = name_tag.ItemID });
            loja05.Trades.Add(nv5);

            villagers.Add(loja05);
        }
        private static void CreateVillagerLoja06(List<Villager> villagers, Profession librarian)
        {
            var loja06 = new Villager
            {
                Name = "Loja 06",
                Description = "Loja 06",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);

            var sharpness_iv = GetItemEnchantedBookSharpnessIV(librarian);
            var bane_of_arthropods_v = GetItemEnchantedBookBaneOfArthropodsV(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept { Amount = 24, ItemID = paper.ItemID });
            nc1.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja06.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept { Amount = 34, ItemID = emerald.ItemID });
            nv1.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv1.Offers.Add(new Offer { Amount = 1, ItemID = sharpness_iv.ItemID });
            loja06.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept { Amount = 4, ItemID = book.ItemID });
            nc2.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja06.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept { Amount = 58, ItemID = emerald.ItemID });
            nv2.Accepts.Add(new Accept { Amount = 1, ItemID = book.ItemID });
            nv2.Offers.Add(new Offer { Amount = 1, ItemID = bane_of_arthropods_v.ItemID });
            loja06.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept { Amount = 5, ItemID = ink_sac.ItemID });
            nc3.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja06.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept { Amount = 1, ItemID = emerald.ItemID });
            nv3.Offers.Add(new Offer { Amount = 4, ItemID = glass.ItemID });
            loja06.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept { Amount = 1, ItemID = book_and_quill.ItemID });
            nv4.Offers.Add(new Offer { Amount = 1, ItemID = emerald.ItemID });
            loja06.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept { Amount = 5, ItemID = emerald.ItemID });
            nc4.Offers.Add(new Offer { Amount = 1, ItemID = clock.ItemID });
            loja06.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept { Amount = 20, ItemID = emerald.ItemID });
            nc5.Offers.Add(new Offer { Amount = 1, ItemID = name_tag.ItemID });
            loja06.Trades.Add(nc5);

            villagers.Add(loja06);
        }
        private static void CreateVillagerLoja07(List<Villager> villagers, Profession librarian)
        {
            var loja07 = new Villager
            {
                Name = "Loja 07",
                Description = "Loja 07",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var respiration_ii = GetItemEnchantedBookRespirationII(librarian);
            var blast_protection_iv = GetItemEnchantedBookBlastProtectionIV(librarian);
            var depth_strider_i = GetItemEnchantedBookDepthStriderI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja07.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(14, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, respiration_ii));
            loja07.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja07.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(38, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, blast_protection_iv));
            loja07.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja07.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja07.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja07.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(14, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, depth_strider_i));
            loja07.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja07.Trades.Add(nc5);

            villagers.Add(loja07);
        }
        private static void CreateVillagerLoja08(List<Villager> villagers, Profession librarian)
        {
            var loja08 = new Villager
            {
                Name = "Loja 08",
                Description = "Loja 08",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var aqua_affinity_I = GetItemEnchantedBookAquaAffinityI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja08.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(6, emerald));
            nv1.Offers.Add(new Offer(1, bookshelf));
            loja08.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja08.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja08.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja08.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(16, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, aqua_affinity_I));
            loja08.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja08.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja08.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja08.Trades.Add(nc5);

            villagers.Add(loja08);
        }
        private static void CreateVillagerLoja09(List<Villager> villagers, Profession librarian)
        {
            var loja09 = new Villager
            {
                Name = "Loja 09",
                Description = "Loja 09",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var quick_charge_ii = GetItemEnchantedBookQuickChargeII(librarian);
            var fire_protection_ii = GetItemEnchantedBookFireProtectionII(librarian);
            var looting_ii = GetItemEnchantedBookLootingII(librarian);
            var mending_i = GetItemEnchantedBookMendingI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja09.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(15, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, quick_charge_ii));
            loja09.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja09.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(13, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, fire_protection_ii));
            loja09.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja09.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(29, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, looting_ii));
            loja09.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja09.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(12, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, mending_i));
            loja09.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja09.Trades.Add(nc5);

            villagers.Add(loja09);
        }
        private static void CreateVillagerLoja10(List<Villager> villagers, Profession librarian)
        {
            var loja10 = new Villager
            {
                Name = "Loja 10",
                Description = "Loja 10",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var protection_iv = GetItemEnchantedBookProtectionIV(librarian);
            var fire_aspect_i = GetItemEnchantedBookFireAspectI(librarian);
            var feather_falling_iii = GetItemEnchantedBookFeatherFallingIII(librarian);
            var silk_touch_i = GetItemEnchantedBookSilkTouchI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja10.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(26, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, protection_iv));
            loja10.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja10.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(15, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, fire_aspect_i));
            loja10.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja10.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(26, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, feather_falling_iii));
            loja10.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja10.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(7, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, silk_touch_i));
            loja10.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja10.Trades.Add(nc5);

            villagers.Add(loja10);
        }
        private static void CreateVillagerLoja11(List<Villager> villagers, Profession librarian)
        {
            var loja11 = new Villager
            {
                Name = "Loja 11",
                Description = "Loja 11",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var respiration_iii = GetItemEnchantedBookRespirationIII(librarian);
            var fortune_ii = GetItemEnchantedBookFortuneII(librarian);
            var fire_protection_iv = GetItemEnchantedBookFireProtectionIV(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja11.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(30, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, fortune_ii));
            loja11.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja11.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(32, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, fire_protection_iv));
            loja11.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja11.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(44, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, respiration_iii));
            loja11.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja11.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja11.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja11.Trades.Add(nc5);

            villagers.Add(loja11);
        }
        private static void CreateVillagerLoja12(List<Villager> villagers, Profession librarian)
        {
            var loja12 = new Villager
            {
                Name = "Loja 12",
                Description = "Loja 12",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var looting_i = GetItemEnchantedBookLootingI(librarian);
            var looting_iii = GetItemEnchantedBookLootingIII(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja12.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(26, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, looting_iii));
            loja12.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja12.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja12.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja12.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja12.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja12.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(19, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, looting_i));
            loja12.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja12.Trades.Add(nc5);

            villagers.Add(loja12);
        }
        private static void CreateVillagerLoja13(List<Villager> villagers, Profession librarian)
        {
            var loja13 = new Villager
            {
                Name = "Loja 13",
                Description = "Loja 13",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var feather_falling_i = GetItemEnchantedBookFeatherFallingI(librarian);
            var thorns_ii = GetItemEnchantedBookThornsII(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja13.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(7, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, feather_falling_i));
            loja13.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja13.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja13.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja13.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(21, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, thorns_ii));
            loja13.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja13.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja13.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja13.Trades.Add(nc5);

            villagers.Add(loja13);
        }
        private static void CreateVillagerLoja14(List<Villager> villagers, Profession librarian)
        {
            var loja14 = new Villager
            {
                Name = "Loja 14",
                Description = "Loja 14",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var sharpness_iii = GetItemEnchantedBookSharpnessIII(librarian);
            var sharpness_iv = GetItemEnchantedBookSharpnessIV(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja14.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(36, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, sharpness_iii));
            loja14.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja14.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(18, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, sharpness_iv));
            loja14.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja14.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja14.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja14.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja14.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja14.Trades.Add(nc5);

            villagers.Add(loja14);
        }
        private static void CreateVillagerLoja15(List<Villager> villagers, Profession librarian)
        {
            var loja15 = new Villager
            {
                Name = "Loja 15",
                Description = "Loja 15",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var feather_falling_ii = GetItemEnchantedBookFeatherFallingII(librarian);
            var thorns_iii = GetItemEnchantedBookThornsIII(librarian);
            var quick_charge_iii = GetItemEnchantedBookQuickChargeIII(librarian);
            var punch_ii = GetItemEnchantedBookPunchII(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja15.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(23, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, quick_charge_iii));
            loja15.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja15.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(11, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, punch_ii));
            loja15.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja15.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(8, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, feather_falling_ii));
            loja15.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja15.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(18, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, thorns_iii));
            loja15.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja15.Trades.Add(nc5);

            villagers.Add(loja15);
        }
        private static void CreateVillagerLoja16(List<Villager> villagers, Profession librarian)
        {
            var loja16 = new Villager
            {
                Name = "Loja 16",
                Description = "Loja 16",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var respiration_i = GetItemEnchantedBookRespirationII(librarian);
            var blast_protection_iv = GetItemEnchantedBookBlastProtectionIV(librarian);
            var depth_strider_i = GetItemEnchantedBookDepthStriderI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja16.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(14, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, respiration_i));
            loja16.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja16.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(38, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, blast_protection_iv));
            loja16.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja16.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja16.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja16.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(14, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, depth_strider_i));
            loja16.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja16.Trades.Add(nc5);

            villagers.Add(loja16);
        }
        private static void CreateVillagerLoja17(List<Villager> villagers, Profession librarian)
        {
            var loja17 = new Villager
            {
                Name = "Loja 17",
                Description = "Loja 17",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var piercing_iii = GetItemEnchantedBookPiercingIII(librarian);
            var piercing_iv = GetItemEnchantedBookPiercingIV(librarian);
            var luck_of_the_sea_ii = GetItemEnchantedBookLuckOfTheSeaII(librarian);
            var infinity_i = GetItemEnchantedBookInfinityI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja17.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(26, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, piercing_iv));
            loja17.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja17.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(18, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, luck_of_the_sea_ii));
            loja17.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja17.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(11, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, infinity_i));
            loja17.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja17.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(18, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, piercing_iii));
            loja17.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja17.Trades.Add(nc5);

            villagers.Add(loja17);
        }
        private static void CreateVillagerLoja18(List<Villager> villagers, Profession librarian)
        {
            var loja18 = new Villager
            {
                Name = "Loja 18",
                Description = "Loja 18",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var compass = GetItemCompass(librarian);
            var name_tag = GetItemNameTag(librarian);
            var piercing_iii = GetItemEnchantedBookPiercingIII(librarian);
            
            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja18.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(6, emerald));
            nv1.Offers.Add(new Offer(1, bookshelf));
            loja18.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja18.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja18.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja18.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(34, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, piercing_iii));
            loja18.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja18.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(4, emerald));
            nc4.Offers.Add(new Offer(1, compass));
            loja18.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja18.Trades.Add(nc5);

            villagers.Add(loja18);
        }
        private static void CreateVillagerLoja19(List<Villager> villagers, Profession librarian)
        {
            var loja19 = new Villager
            {
                Name = "Loja 19",
                Description = "Loja 19",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var looting_i = GetItemEnchantedBookLootingI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja19.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(6, emerald));
            nv1.Offers.Add(new Offer(1, bookshelf));
            loja19.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja19.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja19.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja19.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(8, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, looting_i));
            loja19.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja19.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja19.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja19.Trades.Add(nc5);

            villagers.Add(loja19);
        }
        private static void CreateVillagerLoja20(List<Villager> villagers, Profession librarian)
        {
            var loja20 = new Villager
            {
                Name = "Loja 20",
                Description = "Loja 20",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var clock = GetItemClock(librarian);
            var name_tag = GetItemNameTag(librarian);
            var fire_protection_ii = GetItemEnchantedBookFireProtectionII(librarian);
            var multishot_i = GetItemEnchantedBookMultishotI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja20.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(29, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, fire_protection_ii));
            loja20.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja20.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(6, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, multishot_i));
            loja20.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja20.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja20.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja20.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(5, emerald));
            nc4.Offers.Add(new Offer(1, clock));
            loja20.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja20.Trades.Add(nc5);

            villagers.Add(loja20);
        }
        private static void CreateVillagerLoja21(List<Villager> villagers, Profession librarian)
        {
            var loja21 = new Villager
            {
                Name = "Loja 21",
                Description = "Loja 21",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var compass = GetItemCompass(librarian);
            var name_tag = GetItemNameTag(librarian);
            var aqua_affinity_i = GetItemEnchantedBookAquaAffinityI(librarian);

            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja21.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(6, emerald));
            nv1.Offers.Add(new Offer(1, bookshelf));
            loja21.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja21.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(7, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, aqua_affinity_i));
            loja21.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja21.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja21.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja21.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(4, emerald));
            nc4.Offers.Add(new Offer(1, compass));
            loja21.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja21.Trades.Add(nc5);

            villagers.Add(loja21);
        }
        private static void CreateVillagerLoja22(List<Villager> villagers, Profession librarian)
        {
            var loja22 = new Villager
            {
                Name = "Loja 22",
                Description = "Loja 22",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var compass = GetItemCompass(librarian);
            var name_tag = GetItemNameTag(librarian);
            var depth_strider_ii = GetItemEnchantedBookDepthStriderII(librarian);
            var fortune_ii = GetItemEnchantedBookFortuneII(librarian);
            
            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja22.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(26, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, fortune_ii));
            loja22.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja22.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(14, emerald));
            nv2.Accepts.Add(new Accept(1, book));
            nv2.Offers.Add(new Offer(1, depth_strider_ii));
            loja22.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja22.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja22.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja22.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(4, emerald));
            nc4.Offers.Add(new Offer(1, compass));
            loja22.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja22.Trades.Add(nc5);

            villagers.Add(loja22);
        }
        private static void CreateVillagerLoja23(List<Villager> villagers, Profession librarian)
        {
            var loja23 = new Villager
            {
                Name = "Loja 23",
                Description = "Loja 23",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var bookshelf = GetItemBookshelf(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var glass = GetItemGlass(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var compass = GetItemCompass(librarian);
            var name_tag = GetItemNameTag(librarian);
            
            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja23.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(6, emerald));
            nv1.Offers.Add(new Offer(1, bookshelf));
            loja23.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja23.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja23.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja23.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(1, emerald));
            nv3.Offers.Add(new Offer(4, glass));
            loja23.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja23.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(4, emerald));
            nc4.Offers.Add(new Offer(1, compass));
            loja23.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja23.Trades.Add(nc5);

            villagers.Add(loja23);
        }
        private static void CreateVillagerLoja24(List<Villager> villagers, Profession librarian)
        {
            var loja24 = new Villager
            {
                Name = "Loja 24",
                Description = "Loja 24",
                ProfessionID = librarian.ProfessionID
            };

            var emerald = GetItemEmerald(librarian);
            var paper = GetItemPaper(librarian);
            var book = GetItemBook(librarian);
            var ink_sac = GetItemInkSac(librarian);
            var lantern = GetItemLantern(librarian);
            var book_and_quill = GetItemBookAndQuill(librarian);
            var name_tag = GetItemNameTag(librarian);
            var silk_touch_i = GetItemEnchantedBookSilkTouchI(librarian);
            var fire_protection_ii = GetItemEnchantedBookFireProtectionII(librarian);
            var multishot_i = GetItemEnchantedBookMultishotI(librarian);
            
            var nc1 = new Trade();
            nc1.Accepts.Add(new Accept(24, paper));
            nc1.Offers.Add(new Offer(1, emerald));
            loja24.Trades.Add(nc1);

            var nv1 = new Trade();
            nv1.Accepts.Add(new Accept(8, emerald));
            nv1.Accepts.Add(new Accept(1, book));
            nv1.Offers.Add(new Offer(1, multishot_i));
            loja24.Trades.Add(nv1);

            var nc2 = new Trade();
            nc2.Accepts.Add(new Accept(4, book));
            nc2.Offers.Add(new Offer(1, emerald));
            loja24.Trades.Add(nc2);

            var nv2 = new Trade();
            nv2.Accepts.Add(new Accept(1, emerald));
            nv2.Offers.Add(new Offer(1, lantern));
            loja24.Trades.Add(nv2);

            var nc3 = new Trade();
            nc3.Accepts.Add(new Accept(5, ink_sac));
            nc3.Offers.Add(new Offer(1, emerald));
            loja24.Trades.Add(nc3);

            var nv3 = new Trade();
            nv3.Accepts.Add(new Accept(11, emerald));
            nv3.Accepts.Add(new Accept(1, book));
            nv3.Offers.Add(new Offer(1, fire_protection_ii));
            loja24.Trades.Add(nv3);

            var nv4 = new Trade();
            nv4.Accepts.Add(new Accept(1, book_and_quill));
            nv4.Offers.Add(new Offer(1, emerald));
            loja24.Trades.Add(nv4);

            var nc4 = new Trade();
            nc4.Accepts.Add(new Accept(19, emerald));
            nc4.Accepts.Add(new Accept(1, book));
            nc4.Offers.Add(new Offer(1, silk_touch_i));
            loja24.Trades.Add(nc4);

            var nc5 = new Trade();
            nc5.Accepts.Add(new Accept(20, emerald));
            nc5.Offers.Add(new Offer(1, name_tag));
            loja24.Trades.Add(nc5);

            villagers.Add(loja24);
        }
        private static Item GetItemEnchantedBookMultishotI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: multishot i");
        }
        private static Item GetItemEnchantedBookInfinityI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: infinity i");
        }
        private static Item GetItemEnchantedBookLuckOfTheSeaI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: luck of the sea i");
        }
        private static Item GetItemEnchantedBookLuckOfTheSeaII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: luck of the sea ii");
        }
        private static Item GetItemEnchantedBookPiercingI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: piercing i");
        }
        private static Item GetItemEnchantedBookPiercingII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: piercing ii");
        }
        private static Item GetItemEnchantedBookPiercingIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: piercing iii");
        }
        private static Item GetItemEnchantedBookPiercingIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: piercing iv");
        }
        private static Item GetItemEnchantedBookPunchI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: punch i");
        }
        private static Item GetItemEnchantedBookPunchII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: punch ii");
        }
        private static Item GetItemEnchantedBookSilkTouchI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: silk touch i");
        }
        private static Item GetItemEnchantedBookFeatherFallingI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: feather falling i");
        }
        private static Item GetItemEnchantedBookFeatherFallingII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: feather falling ii");
        }
        private static Item GetItemEnchantedBookFeatherFallingIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: feather falling iii");
        }
        private static Item GetItemEnchantedBookFireAspectI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fire aspect i");
        }
        private static Item GetItemEnchantedBookFireProtectionI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fire protection i");
        }
        private static Item GetItemEnchantedBookFireProtectionII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fire protection ii");
        }
        private static Item GetItemEnchantedBookFireProtectionIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fire protection iii");
        }
        private static Item GetItemEnchantedBookFireProtectionIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fire protection iv");
        }
        private static Item GetItemEnchantedBookQuickChargeI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: quick charge i");
        }
        private static Item GetItemEnchantedBookQuickChargeII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: quick charge ii");
        }
        private static Item GetItemEnchantedBookQuickChargeIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: quick charge iii");
        }
        private static Item GetItemEnchantedBookAquaAffinityI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: aqua affinity i");
        }
        private static Item GetItemEnchantedBookDepthStriderI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: depth strider i");
        }
        private static Item GetItemEnchantedBookDepthStriderII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: depth strider ii");
        }
        private static Item GetItemEnchantedBookBlastProtectionI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bast protection i");
        }
        private static Item GetItemEnchantedBookBlastProtectionII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bast protection ii");
        }
        private static Item GetItemEnchantedBookBlastProtectionIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bast protection iii");
        }
        private static Item GetItemEnchantedBookBlastProtectionIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: blast protection iv");
        }
        private static Item GetItemEnchantedBookRespirationI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: respiration i");
        }
        private static Item GetItemEnchantedBookRespirationII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: respiration ii");
        }
        private static Item GetItemEnchantedBookRespirationIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: respiration iii");
        }
        private static Item GetItemEnchantedBookBaneOfArthropodsI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bane of arthropods i");
        }
        private static Item GetItemEnchantedBookBaneOfArthropodsII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bane of arthropods ii");
        }
        private static Item GetItemEnchantedBookBaneOfArthropodsIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bane of arthropods iii");
        }
        private static Item GetItemEnchantedBookBaneOfArthropodsIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bane of arthropods iv");
        }
        private static Item GetItemEnchantedBookBaneOfArthropodsV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: bane of arthropods v");
        }
        private static Item GetItemCompass(Profession librarian)
        {
            return GetItem(librarian, "compass");
        }
        private static Item GetItemClock(Profession librarian)
        {
            return GetItem(librarian, "clock");
        }
        private static Item GetItemEnchantedBookPowerI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: power i");
        }
        private static Item GetItemEnchantedBookPowerII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: power ii");
        }
        private static Item GetItemEnchantedBookPowerIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: power iii");
        }
        private static Item GetItemEnchantedBookPowerIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: power iv");
        }
        private static Item GetItemBookshelf(Profession librarian)
        {
            return GetItem(librarian, "bookshelf");
        }
        private static Item GetItemEnchantedBookMendingI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: mending i");
        }
        private static Item GetItemEnchantedBookFlameI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: flame i");
        }
        private static Item GetItemEnchantedBookThornsI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: thorns i");
        }
        private static Item GetItemEnchantedBookThornsII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: thorns ii");
        }
        private static Item GetItemEnchantedBookThornsIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: thorns iii");
        }
        private static Item GetItemEnchantedBookSharpnessI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: sharpness i");
        }
        private static Item GetItemEnchantedBookSharpnessII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: sharpness ii");
        }
        private static Item GetItemEnchantedBookSharpnessIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: sharpness iii");
        }
        private static Item GetItemEnchantedBookSharpnessIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: sharpness iv");
        }
        private static Item GetItemLantern(Profession librarian)
        {
            return GetItem(librarian, "lantern");
        }
        private static Item GetItemNameTag(Profession librarian)
        {
            return GetItem(librarian, "name tag");
        }
        private static Item GetItemEnchantedBookProtectionI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: protection i");
        }
        private static Item GetItemEnchantedBookProtectionII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: protection ii");
        }
        private static Item GetItemEnchantedBookProtectionIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: protection iii");
        }
        private static Item GetItemEnchantedBookProtectionIV(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: protection iv");
        }
        private static Item GetItemBookAndQuill(Profession librarian)
        {
            return GetItem(librarian, "book and quill");
        }
        private static Item GetItemGlass(Profession librarian)
        {
            return GetItem(librarian, "glass");
        }
        private static Item GetItemInkSac(Profession librarian)
        {
            return GetItem(librarian, "ink sac");
        }
        private static Item GetItemEnchantedBookFortuneI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fortune i");
        }
        private static Item GetItemEnchantedBookFortuneII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: fortune ii");
        }
        private static Item GetItemEnchantedBookLootingI(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: looting i");
        }
        private static Item GetItemEnchantedBookLootingII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: looting ii");
        }
        private static Item GetItemEnchantedBookLootingIII(Profession librarian)
        {
            return GetItem(librarian, "enchanted book: looting iii");
        }
        private static Item GetItemBook(Profession librarian)
        {
            return GetItem(librarian, "book");
        }
        private static Item GetItemPaper(Profession librarian)
        {
            return GetItem(librarian, "paper");
        }
        private static Item GetItemEmerald(Profession librarian)
        {
            return GetItem(librarian, "emerald");
        }
        private static Item GetItem(Profession librarian, string item)
        {
            return librarian.ProfessionItems.Select(x => x.Item).Where(x => x.Name.ToLower().Equals(item.ToLower())).SingleOrDefault();
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
        private static async Task<Profession> CreateFishermanAsync(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
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
        private static async Task<Profession> CreateFletcherAsync(IDefaultDbContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var fletcher = new Profession
            {
                Order = 5,
                Name = "Fletcher",
                Default = false,
                Description = "Trades bows, crossbows, all types of arrows (except luck) and archery ingredients."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "arrow");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "flint");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bow");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "crossbow");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted bow");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted crowssbow");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "tipped arrow");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stick");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "gravel");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "string");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "feather");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "tripwire hook");

            professionItems.ForEach(professionItem => fletcher.ProfessionItems.Add(professionItem));

            return fletcher;
        }
        #endregion
        #region Create profession cleric
        private static async Task<Profession> CreateClericAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var cleric = new Profession
            {
                Order = 6,
                Name = "Cleric",
                Default = false,
                Description = "Trades magic items like ender pearls, redstone dust, and enchanting or potions ingredients."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "redstone dust");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "lapis lazuli");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "glowstone dust");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "ender pearl");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bottle o' enchanting");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "rotten flesh");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "golden ingot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "rabbit's foot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "scute");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "glass bottle");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "nether wart");

            professionItems.ForEach(professionItem => cleric.ProfessionItems.Add(professionItem));

            return cleric;
        }
        #endregion
        #region Create profession weaponsmith
        private static async Task<Profession> CreateWeaponsmithAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var weaponsmith = new Profession
            {
                Order = 7,
                Name = "Weaponsmith",
                Default = false,
                Description = "Trades minerals, bells and enchanted melee weapons."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron axe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted iron sword");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bell");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond axe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond sword");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coal");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron ingot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "flint");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond");

            professionItems.ForEach(professionItem => weaponsmith.ProfessionItems.Add(professionItem));

            return weaponsmith;
        }
        #endregion
        #region Create profession armorer
        private static async Task<Profession> CreateArmorerAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var armorer = new Profession
            {
                Order = 8,
                Name = "Armorer",
                Default = false,
                Description = "Trades foundry items and sells chain, iron and enchanted diamond armor tiers."
            };


            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron helmet");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron chestplate");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron leggings");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron boots");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bell");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "chainmail leggings");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "chainmail boots");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "chainmail helmet");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "chainmail chestplate");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "shield");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond leggings");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond boots");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond helmet");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted diamond chestplate");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coal");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron ingot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "lava bucket");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond");

            professionItems.ForEach(professionItem => armorer.ProfessionItems.Add(professionItem));

            return armorer;
        }
        #endregion
        #region Create profession toolsmith
        private static async Task<Profession> CreateToolsmithAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var toolsmith = new Profession
            {
                Order = 9,
                Name = "Toolsmith",
                Default = false,
                Description = "Trades minerals, bells and harvest tools."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stone axe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stone pickaxe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stone shovel");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stone hoe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bell");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted iron axe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted iron pickaxe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted iron shovel");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond hoe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond axe");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond shovel");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond pickaxe");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coal");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "iron ingot");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "flint");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diamond");

            professionItems.ForEach(professionItem => toolsmith.ProfessionItems.Add(professionItem));

            return toolsmith;
        }
        #endregion
        #region Create profession librarian
        private static async Task<Profession> CreateLibrarianAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var librarian = new Profession
            {
                Order = 10,
                Name = "Librarian",
                Default = false,
                Description = "Trades enchanted books, clocks, compasses, name tags, glass, ink sacs, lanterns, and book and quills."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "bookshelf");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "enchanted book", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "lantern");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "glass");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "compass");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "clock");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "name tag");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "paper");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "book");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "ink sac");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "book and quill");

            professionItems.ForEach(professionItem => librarian.ProfessionItems.Add(professionItem));

            return librarian;
        }
        #endregion
        #region Create profession cartographer
        private static async Task<Profession> CreateCartographerAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var cartographer = new Profession
            {
                Order = 11,
                Name = "Cartographer",
                Default = false,
                Description = "Trades banners, compasses, banner patterns, papers and various maps, including explorer maps."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "empty map");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "ocean explorer map");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "woodland explorer map");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "item frame");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "banner", false);

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "paper");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "glass pane");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "compass");

            professionItems.ForEach(professionItem => cartographer.ProfessionItems.Add(professionItem));

            return cartographer;
        }
        #endregion
        #region Create profession leatherworker
        private static async Task<Profession> CreateLeatherworkerAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var leatherwork = new Profession
            {
                Order = 12,
                Name = "Leatherworker",
                Default = false,
                Description = "Trades scutes, rabbit hide, and leather-related items."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather pants");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather tunic");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather cap");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather boots");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather horse armor");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "saddle");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "leather");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "flint");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "rabbit hide");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "scute");

            professionItems.ForEach(professionItem => leatherwork.ProfessionItems.Add(professionItem));

            return leatherwork;
        }
        #endregion
        #region Create profession butcher
        private static async Task<Profession> CreateButcherAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var butcher = new Profession
            {
                Order = 13,
                Name = "Butcher",
                Default = false,
                Description = "Trades meats, sweet berries, rabbit stew, and dried kelp blocks."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "rabbit stew");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coocked rabbit");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coocked chicken");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coocked porkchop");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coocked mutton");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coocked beef");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw chicken");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw rabbit");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw porkchop");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "coal");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw beef");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "raw mutton");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "dried kelp block");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "sweet berries");

            professionItems.ForEach(professionItem => butcher.ProfessionItems.Add(professionItem));

            return butcher;
        }
        #endregion
        #region Create profession mason
        private static async Task<Profession> CreateMasonAsync(IDefaultDbContext context, CancellationToken cancellationToken)
        {
            var mason = new Profession
            {
                Order = 14,
                Name = "Mason",
                Default = false,
                Description = "Trades polished stones, terracotta, clay, glazed terracotta and quartz."
            };

            var professionItems = new List<ProfessionItem>();

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "emerald");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "brick");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "chiseled stone bricks");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "polished stone", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "terracotta", false);
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "block of quartz");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "quartz pillar");

            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "clay");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "stone");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "granite");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "andesite");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "diorite");
            await CreateProfessionItemAsync(context, cancellationToken, professionItems, "nether quartz");

            professionItems.ForEach(professionItem => mason.ProfessionItems.Add(professionItem));

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
