namespace TomSwiftUnderMilkWood_Tests
{
    using NUnit.Framework;
    using TomSwiftUnderMilkWood;
    using FluentAssertions;
    using TomSwiftUnderMilkWood.Interfaces;

    [TestFixture]
    public class TextGenerator_Tests
    {

        ITrigramGenerator trigram;
        ITextGenerator textGenerator;

        string startingString = "I wish I may I wish I might";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            trigram = new TrigramGenerator();
            textGenerator = new TextGenerator();
        }

        [Test()]
        public void Test_Get_Random_KeyValue_PairTest()
        {
            // Arrange
            var resultDictionary = trigram.BuildTrigram(startingString);

            //Act
            var keyValuePair = textGenerator.GetRandomKeyValuePair(resultDictionary);

            // Assert
            keyValuePair.Key.Should().NotBeEmpty();
        }

        [Test()]
        public void Test_Get_Random_Value_By_Key()
        {
            // Arrange
            var resultDictionary = trigram.BuildTrigram(startingString);

            //Act
            var value = textGenerator.GetRandomValueFromKeyValuePair("I wish", resultDictionary);

            // Assert
            value.Should().Be("I");
        }

        [Test()]
        public void Test_Check_Dictionary_Updated_Key()
        {
            // Arrange
            var resultDictionary = trigram.BuildTrigram(startingString);
            var key = "I wish";

            //Act
            var value = textGenerator.GetRandomValueFromKeyValuePair(key, resultDictionary);

            // Assert
            resultDictionary[key].Count.Should().Be(1);
        }

        [Test()]
        public void Test_Check_Dictionary_Key_Removed()
        {
            // Arrange
            var resultDictionary = trigram.BuildTrigram(startingString);
            var key = "may I";

            //Act
            var value = textGenerator.GetRandomValueFromKeyValuePair(key, resultDictionary);

            // Assert
            resultDictionary.ContainsKey(key).Should().BeFalse();
        }

        [Test]
        public void Test_Build_Return_String()
        {
            var startingString = "Are you all ready, Tom?  All ready, Mr. Sharp, replied a young man, who was stationed near some complicated apparatus, while the questioner, a dark man, with a nervous manner, leaned over a large tank.  Im going to turn on the gas now, went on the man. Look out for yourself. Im not sure what may happen.  Neither am I, but Im ready for it. If it does explode it cant do much damage.  Oh, I hope it doesnt explode. Weve had so much trouble with the airship, I trust nothing goes wrong now.  Well, turn on the gas, Mr. Sharp, advised Tom Swift Ill watch the pressure gauge, and, if it goes too high, Ill warn you, and you can shut it off.  The man nodded, and, with a small wrench in his hand, went to one end of the tank. The youth, looking anxiously at him, turned his gaze now and then toward a gauge, somewhat like those on steam boilers, which gauge was attached to an aluminum, cigar-chaped affair, about five feet long.  Presently there was a hissing sound in the small frame building where the two were conducting an experiment which meant much to them. The hissing grew louder.  Be ready to jump, advised Mr. Sharp.  I will, answered the lad. But the pressure is going up very slowly. Maybe youd better turn on more gas.  I will. Here she goes! Look out now. You cant tell what is going to happen.  With a sudden hiss, as the powerful gas, under pressure, passed from the tank, through the pipes, and into the aluminum container, the hand on the gauge swept past figure after figure on the dial.  Shut it off! cried Tom quickly. Its coming too fast! Shut her off!  The man sprang to obey the command, and, with nervous fingers, sought to fit the wrench over the nipple of the controlling valve. Then his face seemed to turn white with fear.  I cant move it! Mr. Sharp yelled. Its jammed! I cant shut off the gas! Run! Look out! Shell explode!  Tom Swift, the young inventor, whose acquaintance some of you have previously made, gave one look at the gauge, and seeing that the pressure was steadily mounting, endeavored to reach, and open, a stop-cock, that he might relieve the strain. One trial showed him that the valve there had jammed too, and catching up a roll of blue prints the lad made a dash for the door of the shop. He was not a second behind his companion, and hardly had they passed out of the structure before there was a loud explosion which shook the building, and shattered all the windows in it.  Pieces of wood, bits of metal, and a cloud of sawdust and shavings flew out of the door after the man and the youth, and this was followed by a cloud of yellowish smoke.  Are you hurt, Tom? cried Mr. Sharp, as he swung around to look back at the place where the hazardous experiment had been conducted.  Not a bit! How about you?  Im all right. But it was touch and go! Good thing you had the gauge on, or wed never have known when to run. Well, weve made another failure of it, and the man spoke somewhat bitterly.  Never mind, Mr. Sharp, went on Tom Swift, I think it will be the last mistake. I see what the trouble is now; and know how to remedy it. Come on back, and well try it again; that is if the tank hasnt blown up.  No, I guess thats all right. It was the aluminum container that went up, and thats so light it didnt do much damage. But wed better wait until some of those fumes escape. Theyre not healthy to breathe.  The cloud of yellowish smoke was slowly rolling away, and the man and lad were approaching the shop, which, in spite of the explosion that had taken place in it, was still intact, when an aged man, coming from a handsome house not far off, called out:  Tom, is anyone hurt?  No, dad. Were all right.  What happened?  Well, we had another explosion. We cant seem to get the right mixture of the gas, but I think weve had the last of our bad luck. Were going to try it again. Up to now the gas has been too strong, the tank too weak, or else our valve control is bad.  Oh dear, Mr. Swift! Do tell them to be careful! a womans voice chimed in. Im sure something dreadful will happen! This is about the tenth time something has blown up around here, and——  Its only the ninth, Mrs. Baggert, interrupted Tom, somewhat indignantly.  Well, goodness me! Isnt nine almost as bad as ten? There I was, just putting my bread in the oven, went on Mrs. Baggert, the housekeeper, and I was so startled that I dropped it, and now the dough is all over the kitchen floor. I never saw such a muss.  Im sorry, answered the youth, trying not to laugh. Well see that it doesnt happen again.  Yes; thats what you always say, rejoined the motherly-looking woman, who looked after the interests of Mr. Swifts home.  Well, we mean it this time, retorted the lad. We see where our mistake was; dont we. Mr. Sharp?  I think so, replied the other seriously.  Come on back, and well see what damage was done, proposed Tom. Maybe we can rig up another container, mix some fresh gas, and make the final experiment this afternoon.  Now do be careful, cautioned Mr. Swift, the aged inventor, once more. Im afraid you two have set too hard a task for yourselves this time.  No we havent, dad, answered his son. Youll see us yet skimming along above the clouds.  Humph! If you go above the clouds I shant be very likely to see you. But go slowly, now. Dont blow the place up again.  Mr. Swift went into the house, followed by Mrs. Baggert, who was loudly bewailing the fate of her bread. Tom and Mr. Sharp started toward the shop where they had been working. It was one of several buildings, built for experimental purposes and patent work by Mr. Swift, near his home.  It didnt do so very much damage, observed Tom, as he peered in through a window, void of all the panes of glass. We can start right in.  Hold on! Wait! Dont try it now! exclaimed Mr. Sharp, who talked in short, snappy sentences, which, however, said all he meant. The fumes of that gas arent good to breathe. Wait until they have blown away. It wont be long. Its safer.  He began to cough, choking from the pungent odor, and Tom felt an unpleasant tickling sensation in his throat.  Take a walk around, advised Mr. Sharp. Ill be looking over the blue prints. Lets have em.  Tom handed over the roll he had grabbed up when he ran from the shop, just before the explosion took place, and, while his companion spread them out on his knee, as he sat on an up-turned barrel, the lad walked toward the rear of the large yard. It was enclosed by a high board fence, with a locked gate, but Tom, undoing the fastenings, stepped out into a broad, green meadow at the rear of his fathers property. As he did so he saw three boys running toward him.  Hello! exclaimed our hero. There are Andy Foger, Sam Snedecker and Pete Bailey. I wonder what theyre heading this way for?  On the trio came, increasing their pace as they caught sight of Tom. Andy Foger, a red-haired and squint-eyed lad, a sort of town bully, with a rich and indulgent father, was the first to reach the young inventor.  How—how many are killed? panted Andy.  Shall we go for doctors? asked Sam.  Can we see the place? blurted out Pete, and he had to sit down on the grass, he was so winded.  Killed? Doctors? repeated Tom, clearly much puzzled. What are you fellows driving at, anyhow?  Wasnt there a lot of people killed in the explosion we heard? demanded Andy in eager tones.  Not a one, replied Tom.  There was an explosion! exclaimed Pete. We heard it, and you cant fool us!  And we saw the smoke, added Snedecker.";

            // Arrange
            var resultDictionary = trigram.BuildTrigram(startingString);

            var returnValue = string.Empty;

            //Act
            returnValue = textGenerator.BuildRandomReturnString(resultDictionary, returnValue);

            // Assert
            returnValue.Length.Should().BeGreaterThan(1);


        }

    }
}
