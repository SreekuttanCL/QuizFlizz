using System;
namespace QuizApp.Model
{
    public class Questions
    {
        public string name { get; set; }
        public bool answer { get; set; }
        public Questions()
        {
        }
    }
}
/*


    //comics questions
            await AddQuestion("Superman was created by Marvel.", false,"comics");
            await AddQuestion("Bruce Wayne became Batman after he face the tragedy when his parents were murdered.", true, "comics");
            await AddQuestion("Famous Funnies is considered the first true comicbook?", true, "comics");
            await AddQuestion("'Garfield' is a popular comic series featuring a cat and its owner 'Jon'.", true, "comics");
            await AddQuestion("Spiderman was created by DC.", false, "comics");
            await AddQuestion("The character 'Deadpool is played by Wade Wilson?", true, "comics");
            await AddQuestion("Ryan Renolds has played in both DC and Disney universe as different superheroes.", true, "comics");
            await AddQuestion("Green Arrow's Apprentice name is Flashy.", false, "comics");
            await AddQuestion("Captain America was co-created by Stan Lee?", false, "comics");
            await AddQuestion("Aquaman was created by DC.", true, "comics");
            //movies questions
            await AddQuestion("'The Hurt Locker' won the Academy Award for Best picture in 2009.", true, "movies");
            await AddQuestion("Gone with the wind was the first movie to win the Oscar for Best picture?", false, "movies");
            await AddQuestion("LA filmed in Vancouver.", false, "movies");
            await AddQuestion("Batman made his first movie apperance in the 1940s.", false, "movies");
            await AddQuestion("Tom Hanks speaks less than 200 words in Toy Story 2.", false, "movies");
            await AddQuestion("Paul Newman starred in the 1961 movie The Hustler.", true, "movies");
            await AddQuestion("Academy Award or Oscar was first presented in 1929.", true, "movies");
            await AddQuestion("Judy Garland did not star as Dorothy Gale in The Wizard of Oz.", false, "movies");
            await AddQuestion("Ridley Scott was the director of the epic movie Gladiator in 2000", true, "movies");
            await AddQuestion("Tom Hanks played as Jack Dawson in Titanic", false, "movies");
            //music
            await AddQuestion("Micheal Jackson topped the UK chart in 1995 with 'You Are Not Alone'.", true, "music");
            await AddQuestion("'The Colour of My Love' is a 1995 studio album from Katy Perry.", false, "music");
            await AddQuestion("Eminem was responsible for the fourth biggest selling single of 1990.", false, "movies");
            await AddQuestion("Queen had a 1991 Christmas number one with a re-issue of Bohemian Rhapsody.", true, "music");
            await AddQuestion("The Simpsons reached number one in the UK Singles Chart with Bart's single 'Do The Bartman' in 1991.", true, "music");
            await AddQuestion("Spice girls were the first group to have their first six singles all reach number one?", true, "music");
            await AddQuestion("Usher release the song 'You Make Me Wanna...' in 1998", false, "music");
            await AddQuestion("Sir Elton John's middle name is Hercules.", true, "music");
            await AddQuestion("Elvis Presley has more than 15 number-one hits in the United States.", true, "music");
            await AddQuestion("'Walk this Way' was a hit for Guns N' Roses.", false, "music");
            //sports
            await AddQuestion("Celtic is an association football team based in Wales.", false, "sports");
            await AddQuestion("The Olympic Games were held in Atlanta in 1992\n", false, "sports");
            await AddQuestion("There are 15 players on a rugby union team\n", true, "sports");
            await AddQuestion("After a white belt, the first belt that a martial arts novice is able to achieve is the green belt", false, "sports");
            await AddQuestion("The backstroke is the slowest of the four competitive swimming strokes\n", false, "sports");
            await AddQuestion("There are 22 teams in the Premier League.", false, "sports");
            await AddQuestion("Nadia Comăneci achieved her perfect 10.0 score at the 1976 Olympic Games.", true, "sports");
            await AddQuestion("A score of deuce means the score is 60-60.", false, "sports");
            await AddQuestion("There are six balls in an over in cricket.", true, "sports");
            await AddQuestion("The world record for the women's triple jump is over 18 metres (59 feet)\n", false, "sports");
            //Politics
            await AddQuestion("Socrates, the great Greek philosopher, never wrote anything down.\n", true, "politics");
            await AddQuestion("The Russian parliament building in Moscow is called the White House.", true, "politics");
            await AddQuestion("The swastika was traditionally a symbol of bad luck.", false, "politics");
            await AddQuestion("The greater the distribution of wealth and education in a given society, the more likely that the seeds of the democracy will grow.", true, "politics");
            await AddQuestion("The American CIA is the equivalent organization of Britain's CID.", false, "politics");
            await AddQuestion("Washington, Jefferson, Lincoln, and Grant are the four presidents' heads sculpted into Mount Rushmore.", false, "politics");
            await AddQuestion("ccording to aristotle, the true measure of a political system is found in the kind of citizen it produces", true, "politics");
            await AddQuestion("A good person and a good citizen are synonymous.", false, "politics");
            await AddQuestion("According to pluralist, the US political system is centralized.", true, "politics");
            await AddQuestion("The internet has given power to the people and encourages more gassroots political actions.", true, "politics");
            //History
            await AddQuestion("Alexander the Great was the first Pharaoh of the Argead Dynasty and he founded the city of Alexandria.", true, "history");
            await AddQuestion("Nero was the first Roman Emperor", false, "history");
            await AddQuestion("Sir Winston Churchill was a Labour Prime Minister.", false, "history");
            await AddQuestion("The Iron Age comes after the Bronze Age.", true, "history");
            await AddQuestion("The White House was built before Big Ben.", true, "history");
            await AddQuestion("The Berlin Wall was constructed by East Germany.", true, "history");
            await AddQuestion("The Ming Dynasty was the final Chinese Dynasty.", false, "history");
            await AddQuestion("Norway separated from Sweden in the 20th Century.", true, "history");
            await AddQuestion("Genghis Khan's real name was Temujin.", true, "history");
            await AddQuestion("Socrates was sentenced to death.", true, "history");
            //Science
            await AddQuestion("The longest bone in the human body is the femur.", true, "science");
            await AddQuestion("Joules are a scientific unit of Power.", false, "science");
            await AddQuestion("Pluto is considered to be a planet in our solar system.", false, "science");
            await AddQuestion("Earth's atmosphere is mostly Nitrogen.", true, "science");
            await AddQuestion("Centipedes are considered insects.", false, "science");
            await AddQuestion("When Hydrogen nuclei fuse, total mass decreases.", true, "science");
            await AddQuestion("A lightyear is a unit of distance", true, "science");
            await AddQuestion("sin²θ + cos²θ = 1", true, "science");
            await AddQuestion("Jupiter was first discovered by Galileo Galilei.", false, "science");
            await AddQuestion("White Blood Cells have a nucleus.", true, "science");
            //Countries  
            await AddQuestion("Singapore is the world's most densely-populated country.", true, "countries");
            await AddQuestion("Every continent (except Antarctica) contains a country that is one of the 10 largest in the world in area.\n", true, "countries");
            await AddQuestion("There is a NATO country in Africa.", false, "countries");
            await AddQuestion("India is larger in both area and population than Argentina.", true, "countries");
            await AddQuestion("The two countries that border the most amount of countries also border each other.", true, "countries");
            await AddQuestion("There are 3 total countries that contain the word 'Guinea' in their name.", false, "countries");
            await AddQuestion("The Andes Mountains go through Guyana.", false, "countries");
            await AddQuestion("The Mongol empire at one point stretched all the way to modern-day Romania.", true, "countries");
            await AddQuestion("There are only 2 countries in South America that do not have any coastline.", true, "countries");
            await AddQuestion("Russia's land area is larger than the moon's total surface area.", false, "countries");
            //Animals
            await AddQuestion("A flamingo can only eat when its head is upside down.", true, "animals");
            await AddQuestion("There is a mammal in Australia that has sex until it disintegrates.", true, "animals");
            await AddQuestion("A sea turtle's flipper can exert more pressure per square inch than a jackhammer.", false, "animals");
            await AddQuestion("A giraffe that loses a leg is just as mobile as a four legged giraffe.", false, "animals");
            await AddQuestion("Moles will starve to death if they don't eat every few hours.", true, "animals");
            await AddQuestion("A hummingbird weighs less than a penny.", true, "animals");
            await AddQuestion("Beeswax can survive temperatures of up to 200 degrees and can even shield bees from radiation\t", false, "animals");
            await AddQuestion("The average frog tongue can extend about 2 feet.", false, "animals");
            await AddQuestion("A duck's quack does not echo due to its unique sonic capability.", false, "animals");
            await AddQuestion("A butterfly tastes with its feet.", true, "animals");
            //Human body
            await AddQuestion("Women are born better smellers than men and remain better smellers over life.", true, "human body");
            await AddQuestion("The human brain cell can hold 5 times as much information as the Encyclopedia Britannica.", true, "human body");
            await AddQuestion("The largest cell in the human body is the female egg and the smallest is the male sperm.", true, "human body");
            await AddQuestion("You use 200 muscles to take one step.", true, "human body");
            await AddQuestion("Every day an adult body produces 300 billion new cells.\t", true, "human body");
            await AddQuestion("Sunday is the day of the week when the risk of heart attack is greatest.\t", false, "human body");
            await AddQuestion("The human body has only five senses.", false, "human body");
            await AddQuestion("Knuckle Cracking Causes Arthritis.", false, "human body");
            await AddQuestion("It takes seven years for swallowed gum to exit the body.", false, "human body");
            await AddQuestion("Exactly 50% of human waste is made of water.", false, "human body");


    */
