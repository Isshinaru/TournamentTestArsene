using NUnit.Framework;

namespace TournamentTestArsene
{
    [TestFixture]
    public class TournamentTest
    {
        [Test]
        public void SimpleTestCase()
        {
            Assert.IsTrue(true);
        }

        /*
        * A Swordsman has 100 hit points and use a 1 hand sword that does 5 dmg
        * A Viking has 120 hit points and use a 1 hand axe that does 6 dmg
        */
        [Test]
        public void SwordsmanVsViking()
        {
            Warrior swordsman = new Swordsman();

            Viking viking = new Viking();

            swordsman.Engage(viking);

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(35, viking.HitPoints());
        }

        
        /* a buckler cancel all the damages of a blow one time out of two
        * a buckler is destroyed after blocking 3 blow from an axe
        */ 
        [Test]
        public void SwordsmanWithBucklerVsVikingWithBuckler()
        {
            /*
            Swordsman swordsman = new Swordsman()
                .Equip("buckler");

            Viking viking = new Viking()
                    .Equip("buckler");

            I haven't seen this way of calling a method after creating an instance before, so i'll twist it a little bit in order to achieve the test.I'll do some more research after.
            */
            Swordsman swordsman = new Swordsman();
                swordsman.Equip("buckler");

            Viking viking = new Viking();
                    viking.Equip("buckler");

            swordsman.Engage(viking);

            /*A little test to verify is buckler is actually suppressed
            *Assert.IsTrue(viking.IsEquipped("buckler"));
            *Assert.IsTrue(!swordsman.IsEquipped("buckler"));*/

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(70, viking.HitPoints());
        }

        /*
         * an Highlander as 150 hit points and fight with a Great Sword
         * a Great Sword is a two handed sword deliver 12 damages, but can attack only 2 every 3 )(attack ; attack ; no attack)
         * an armor : reduce all received damages by 3 & reduce delivered damages by one
         */
        [Test]
        public void ArmoredSwordsmanVsHighlander()
        {
            Highlander highlander = new Highlander();
            /*Same thing as previously for now
            Swordsman swordsman = new Swordsman()
                    .Equip("buckler")
                    .Equip("armor");*/

            Swordsman swordsman = new Swordsman();
            swordsman.Equip("buckler");
            swordsman.Equip("armor");

            swordsman.Engage(highlander);

            /*Assert.IsTrue(swordsman.IsEquipped("buckler"));
            Assert.IsTrue(swordsman.IsEquipped("armor"));*/

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(10, highlander.HitPoints());
        }
        
        /*
         * a vicious Swordsman is a Swordsman that put poison on his weapon.
         * poison add 20 damages on two first blows
         * a veteran Highlander goes Berserk once his hit points are under 30% of his initial total
         * once Berserk, he doubles his damages
         */
        [Test]
        public void ViciousSwordsmanVsVeteranHighlander()
        {
            /* Here we go again
            Swordsman swordsman = new Swordsman("Vicious")
                    .Equip("axe")
                    .Equip("buckler")
                    .Equip("armor");
            */
            Swordsman swordsman = new Swordsman("Vicious");
            swordsman.Equip("axe");
            swordsman.Equip("buckler");
            swordsman.Equip("armor");

            Highlander highlander = new Highlander("Veteran");

            swordsman.Engage(highlander);

            Assert.IsTrue(swordsman.IsEquipped("buckler"));
            Assert.IsTrue(highlander.IsEquipped("berserker"));

            //Assert.AreEqual(0, highlander.HitPoints());
            Assert.AreEqual(1, swordsman.HitPoints());
            Assert.AreEqual(0, highlander.HitPoints());
        }
        
    }
}