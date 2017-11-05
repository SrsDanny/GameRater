using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRater.DAL.Models;

namespace GameRater.DAL
{
    public class GameRaterDatabaseInitializer : DropCreateDatabaseIfModelChanges<GameRaterContext>
    {
        protected override void Seed(GameRaterContext context)
        {
            var rnd = new Random();
            foreach (var game in GetGames())
            {
                game.Reviews = GetReviews(game).Where(_ => rnd.NextDouble() > .3).ToList();
                game.ReviewScore = game.Reviews.Average(review => review.Score);
                context.Games.Add(game);
            }

            base.Seed(context);
        }

        private static List<Review> GetReviews(Game game)
        {
            return new List<Review>
            {
                new Review
                {
                    Game = game,
                    Content =
                        @"Deserunt eu est excepteur ea non magna est. Mollit sint veniam minim incididunt laborum commodo magna in aliqua amet dolore elit laboris est. Ipsum dolore officia pariatur cupidatat cillum dolor aliquip reprehenderit amet laborum labore elit anim sint. Duis reprehenderit consectetur eu esse labore elit aute occaecat nisi proident duis duis do.",
                    Score = 2
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Do amet in officia laborum. Dolor exercitation veniam ipsum duis reprehenderit ut. Reprehenderit officia adipisicing et velit proident sit sint cupidatat.",
                    Score = 1
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Sunt et eiusmod magna do exercitation exercitation minim commodo deserunt voluptate quis incididunt mollit. In sunt exercitation amet reprehenderit culpa cillum aliqua adipisicing ex mollit. Laborum ex incididunt cupidatat nostrud veniam veniam occaecat.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Enim anim minim occaecat aliquip aute officia nisi sint labore veniam et ut pariatur. Minim consequat veniam ullamco officia aliquip amet et. Occaecat id pariatur exercitation et minim proident fugiat occaecat. Enim consequat sunt in et non nisi.",
                    Score = 1
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Commodo qui laborum eu pariatur magna. Reprehenderit deserunt duis non deserunt labore laborum labore velit officia amet veniam incididunt. Non mollit incididunt magna pariatur culpa. Eu id qui ullamco et quis incididunt sit consectetur deserunt occaecat pariatur anim.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Pariatur consequat ullamco ut magna magna proident exercitation aliquip fugiat. Velit est adipisicing tempor mollit ut. Occaecat ullamco deserunt ad velit. Sunt quis nisi nulla eiusmod eu dolore ea proident eu proident labore consectetur. Consectetur magna esse irure cupidatat eiusmod proident do in aliqua reprehenderit.",
                    Score = 1
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Proident sit incididunt reprehenderit incididunt excepteur est anim. Deserunt duis quis aliqua ad reprehenderit aute incididunt cupidatat. Cillum sunt pariatur ullamco eiusmod consectetur. Cillum mollit labore quis aliqua consectetur enim adipisicing. Ad dolor labore in deserunt proident ut velit enim do eu id non.",
                    Score = 5
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Ex consequat nostrud exercitation ullamco quis consectetur nisi consectetur voluptate mollit. Nulla id tempor aliquip commodo sint nostrud elit ut voluptate velit consectetur laboris est. Mollit ullamco non esse voluptate sit non proident tempor consequat id. Qui consequat quis pariatur reprehenderit ad anim do esse. Sint Lorem cillum qui ipsum irure et id consequat eu laboris veniam.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Eiusmod officia tempor esse deserunt ut non ipsum in incididunt veniam exercitation elit excepteur dolor. Mollit deserunt dolore ex elit ad ut. Consequat pariatur cupidatat laboris voluptate incididunt nostrud excepteur qui cillum voluptate laboris culpa minim ullamco. Ex consectetur in duis cupidatat qui cillum veniam.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Ullamco anim cupidatat non nulla ut dolore. Lorem aliqua labore tempor irure cillum Lorem adipisicing adipisicing sint nulla occaecat. Minim pariatur veniam officia fugiat nostrud velit ea mollit. Qui ullamco incididunt nulla officia.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Elit consectetur occaecat officia ut cillum sit elit eiusmod esse. Culpa mollit amet ad nostrud tempor tempor proident quis ipsum ut in occaecat minim. Nisi eu non ex laboris reprehenderit nulla dolor irure officia duis incididunt.",
                    Score = 5
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Nulla excepteur labore ullamco non dolore ex aute voluptate do consequat enim laboris fugiat non. Culpa labore enim velit do sint pariatur magna. Adipisicing ex proident amet voluptate enim id consectetur. Non voluptate mollit duis sunt nostrud proident laboris.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Reprehenderit aliquip laboris laborum excepteur aliquip fugiat reprehenderit laboris nisi eiusmod dolore do in. Occaecat est minim amet eiusmod Lorem ipsum sunt. Exercitation dolor tempor dolore voluptate aute Lorem ea aliquip aliquip fugiat elit minim aute reprehenderit. Sunt dolor ipsum fugiat nostrud labore reprehenderit proident sit laborum reprehenderit aliquip nisi officia. Minim dolore labore eiusmod dolor voluptate dolore dolore duis.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Velit sunt officia elit laboris eiusmod. Qui ullamco aliqua proident ad reprehenderit. Exercitation do commodo qui cupidatat dolor irure ullamco commodo reprehenderit veniam excepteur. Est mollit ullamco Lorem sunt ut ipsum aute ad. Anim eiusmod irure dolor cupidatat velit pariatur.",
                    Score = 3
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Exercitation adipisicing nisi exercitation eu adipisicing sunt. Ullamco laboris consectetur tempor nulla cillum labore duis magna excepteur amet magna. Ex elit do est incididunt quis sit eu.",
                    Score = 5
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Anim consectetur exercitation reprehenderit est enim laborum fugiat minim in eiusmod labore quis. Do adipisicing proident velit sunt aliqua est id incididunt officia Lorem pariatur labore. Reprehenderit ex ad dolore elit quis in ullamco aute velit dolore cillum elit.",
                    Score = 3
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Nostrud aliquip id cupidatat eu irure dolor veniam labore cupidatat laboris tempor. Ullamco incididunt exercitation do excepteur aliquip excepteur. Eiusmod voluptate adipisicing ex ipsum dolor cillum. Ut sint nulla veniam nulla in sit irure eiusmod nisi reprehenderit eiusmod.",
                    Score = 1
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Ut do esse incididunt veniam non. Dolor consequat deserunt qui veniam proident aliquip aute adipisicing consectetur aliqua. Laboris eu nisi cillum exercitation non veniam aliquip deserunt consectetur sint consequat.",
                    Score = 2
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Officia consectetur nulla proident nisi Lorem reprehenderit anim ad non et nisi laborum. Officia incididunt mollit est esse. Adipisicing dolor exercitation ullamco ut tempor id qui sit tempor dolore occaecat reprehenderit. Reprehenderit non voluptate esse sit culpa occaecat nisi ea adipisicing aute occaecat nulla ad adipisicing.",
                    Score = 4
                },
                new Review
                {
                    Game = game,
                    Content =
                        @"Laboris excepteur ex proident in sunt. Elit exercitation non sit Lorem. Ea et occaecat esse magna. Aliqua occaecat nostrud incididunt fugiat occaecat ut Lorem aute minim ea cillum.",
                    Score = 2
                },
            };
        }

        private static List<Game> GetGames()
        {
            return new List<Game>
            {
                new Game
                {
                    Title = @"Call of Duty: WWII",
                    Summary =
                        @"Call of Duty: WWII creates the definitive World War II next generation experience across three different game modes: Campaign, Multiplayer, and Co-Operative. Featuring stunning visuals, the Campaign transports players to the European theater as they engage in an all-new Call of Duty story set in iconic World War II battles. Multiplayer marks a return to original, boots-on-the ground Call of Duty gameplay. Authentic weapons and traditional run-and-gun action immerse you in a vast array of World War II-themed locations. The Co-Operative mode unleashes a new and original story in a standalone game experience full of unexpected, adrenaline-pumping moments.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/e7vzqpimo6pwovewqqli.jpg"
                },
                new Game
                {
                    Title = @"Super Mario Odyssey",
                    Summary =
                        @"The game has Mario leaving the Mushroom Kingdom to reach an unknown open world-like setting, like Super Mario 64 and Super Mario Sunshine.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/z9wpjmwyfy8pdoedpvih.jpg"
                },
                new Game
                {
                    Title = @"Middle-earth: Shadow of War",
                    Summary =
                        @"Go behind enemy lines to forge your army, conquer Fortresses and dominate Mordor from within. Experience how the award winning Nemesis System creates unique personal stories with every enemy and follower, and confront the full power of the Dark Lord Sauron and his Ringwraiths in this epic new story of Middle-earth.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/xjqnuckrivp1iwvpneh5.jpg"
                },
                new Game
                {
                    Title = @"Assassin’s Creed: Origins",
                    Summary =
                        @"For the last four years, the team behind Assassin’s Creed IV Black Flag has been crafting a new beginning for the Assassin’s Creed franchise. 
 
Set in Ancient Egypt, players will journey to the most mysterious place in history, during a crucial period that will shape the world and give rise to the Assassin’s Brotherhood. Plunged into a living, systemic and majestic open world, players are going to discover vibrant ecosystems, made of diverse and exotic landscapes that will provide them with infinite opportunities of pure exploration, adventures and challenges. 
 
Powered by a new fight philosophy, Assassin&#x27;s Creed Originsembraces a brand new RPG direction where players level up, loot, and choose abilities to shape and customize their very own skilled Assassin as they grow in power and expertise while exploring the entire country of Ancient Egypt.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/l2dza03yjs6j5u6uuak2.jpg"
                },
                new Game
                {
                    Title = @"Destiny 2",
                    Summary =
                        @"In Destiny 2, the last safe city on Earth has fallen and lays in ruins, occupied by a powerful new enemy and his elite army, the Red Legion. Every player creates their own character called a “Guardian,” humanity’s chosen protectors. As a Guardian in Destiny 2, players must master new abilities and weapons to reunite the city’s forces, stand together and fight back to reclaim their home.  
  
In Destiny 2 players will answer this call, embarking on a fresh story filled with new destinations around our solar system to explore, and an expansive amount of activities to discover. There is something for almost every type of gamer in Destiny 2, including gameplay for solo, cooperative and competitive players set within a vast, evolving and exciting universe.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/o1yenovvskchtjrl48v5.jpg"
                },
                new Game
                {
                    Title = @"Sonic Forces",
                    Summary =
                        @"The game follows Sonic the Hedgehog as a member of a resistance force against Doctor Eggman, who has taken over the world with the help of his robot army and a mysterious new villain known as Infinite. Gameplay is similar to Sonic Generations with players controlling &quot;Classic&quot; and &quot;Modern&quot; versions of the titular character; the former plays from a 2.5D side-scrolling view reminiscent of the original Sonic games on the Sega Genesis, while the latter uses three-dimensional gameplay similar to Sonic Unleashed and Sonic Colors. In addition to the two Sonics, Sonic Forces also introduces a third gameplay mode featuring the &quot;Avatar&quot;, the player&#x27;s own custom character.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/x1kfyx5ehwnufchjxr7e.jpg"
                },
                new Game
                {
                    Title = @"Monster Hunter: World",
                    Summary =
                        @"Monster Hunter: World sees players take on the role of a hunter that completes various quests to hunt and slay monsters within a lively living and breathing eco-system full of predators…. and prey. In the video you can see some of the creatures you can expect to come across within the New World, the newly discovered continent where Monster Hunter: World is set, including the Great Jagras which has the ability to swallow its prey whole and one of the Monster Hunter series favourites, Rathalos. 
 
Players are able to utilise survival tools such as the slinger and Scoutfly to aid them in their hunt. By using these skills to their advantage hunters can lure monsters into traps and even pit them against each other in an epic fierce battle. Can our hunter successfully survive the fight and slay the Anjanath? He’ll need to select his weapon choice carefully from 14 different weapon classes and think strategically about how to take the giant foe down. Don’t forget to pack the camouflaging ghillie suit!",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/ujjuhfkfvoy0r9urplhw.jpg"
                },
                new Game
                {
                    Title = @"WWE 2K18",
                    Summary =
                        @"This latest entry in 2k Sports WWE series boasts a next generation graphics engine, the largest roster of any WWE game before it with the rosters updated gimmick sets and show stylings to closely resembles the current TV product, and the first WWE 2k only be released on current generation hardware. 

Seth Rollins was revealed to be the cover star, and the game&#x27;s slogan is &quot;Be Like No One.&quot;",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/qhlafqriozciovqu1hrl.jpg"
                },
                new Game
                {
                    Title = @"South Park: The Fractured But Whole",
                    Summary =
                        @"Players will once again assume the role of the New Kid, and join South Park favorites Stan, Kyle, Kenny and Cartman in a new hilarious and outrageous adventure. This time, players will delve into the crime-ridden underbelly of South Park with Coon and Friends. 
 
This dedicated group of crime fighters was formed by Eric Cartman whose superhero alter-ego, The Coon, is half man, half raccoon. As the New Kid, players will join Mysterion, Toolshed, Human Kite, Mosquito, Mint Berry Crunch and a host of others to battle the forces of evil while Coon strives to make his team the most beloved superheroes in history.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/hs8jyr19xcpzbq4r0dco.jpg"
                },
                new Game
                {
                    Title = @"ELEX",
                    Summary =
                        @"An action, role-playing open world game for PC and Consoles, Elex was developed by Piranha Bytes, creators of the award winning Gothic series and is set in a brand new, post-apocalyptic, Science-Fantasy universe where magic meets mechs. 
 
&quot;Advanced in technology, civilized and with a population of billions, Magalan was a planet looking to the future. Then the meteor hit. 
 
Those who survived are now trapped in a battle to survive, a struggle to decide the fate of a planet. At the center of this fight is the element “Elex”. A precious, limited resource that arrived with the meteor, Elex can power machines, open the door to magic, or re-sculpt life into new, different forms. 
 
But which of these choices should be the future of Magalan? Can technology or magic save this world? Or will this new power destroy all those left alive amongst the ruins?&quot;",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/k4nbupwvotwyumiicyzq.jpg"
                },
                new Game
                {
                    Title = @"Dead Island 2",
                    Summary =
                        @"Welcome to Zombie California! Slay and survive with style in this co-op playground. Explore the vast Golden State, from lush forests to sunny beaches. Wield a variety of over-the-top, hand-crafted weapons against human and undead enemies. Upgrade your vehicles, grab your friends, and take a permanent vacation to the zombie apocalypse. Paradise meets hell and you are the matchmaker!",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/lumgkti6rht3evlbu8xw.jpg"
                },
                new Game
                {
                    Title = @"Pokémon Ultra Sun",
                    Summary =
                        @"&quot;Take on the role of a Pokémon Trainer and uncover new tales, and unravel the mystery behind the two forms reminiscent of the Legendary Pokémon. With new story additions and features this earns Pokémon™ Ultra Sun and Pokémon Ultra Moon the name &quot;Ultra!&quot; Another adventure is about to begin! 
 
New Pokémon forms have been discovered in the Aloha region in Pokémon Ultra Sun and Pokémon Ultra Moon! These forms are reminiscent of the Legendary Pokémon Solgaleo, Lunala, and Necrozma, first revealed in Pokémon Sun and Pokémon Moon. Head out on an epic journey as you solve the mystery behind these fascinating Pokémon! In this expanded adventure, get ready to explore more of the Alola region, catch more amazing Pokémon, and battle more formidable foes in Pokémon Ultra Sun and Pokémon Ultra Moon!&quot;",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/tkddrz7k84fhgxwtrcho.jpg"
                },
                new Game
                {
                    Title = @"Wolfenstein II: The New Colossus",
                    Summary =
                        @"Wolfenstein II: The New Colossus is the highly anticipated sequel to the critically acclaimed, Wolfenstein: The New Order developed by the award-winning studio MachineGames. An exhilarating adventure brought to life by the industry-leading id Tech 6, Wolfenstein II sends players to Nazi-controlled America on a mission to recruit the boldest resistance leaders left. Fight the Nazis in iconic American locations, equip an arsenal of badass guns, and unleash new abilities to blast your way through legions of Nazi soldiers in this definitive first-person shooter. America, 1961. The Nazis maintain their stranglehold on the world. You are BJ Blazkowicz, aka “Terror-Billy,” member of the Resistance, scourge of the Nazi empire, and humanity’s last hope for liberty. Only you have the guts, guns, and gumption to return stateside, kill every Nazi in sight, and spark the second American Revolution.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/kb003ljwkc8hxmlrwpkg.jpg"
                },
                new Game
                {
                    Title = @"Middle-earth: Shadow of War - The Desolation of Mordor",
                    Summary = @"TBA",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/pj1rehuwltex6okxdo9f.jpg"
                },
                new Game
                {
                    Title = @"Sky Break",
                    Summary =
                        @"Sky Break is an open-world game on a stormy abandoned planet filled with wild mechas. Learn to master this world and to hack the mechas if you want a chance to survive.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/ebebxnv543d4y5e4wazd.jpg"
                },
                new Game
                {
                    Title = @"Star Wars Battlefront II",
                    Summary =
                        @"Embark on an endless Star Wars™ action experience from the best-selling Star Wars HD video game franchise of all time. Experience rich multiplayer battlegrounds across all 3 eras - prequel, classic and new trilogy - or rise as a new hero and discover an emotionally gripping single-player story spanning thirty years. 
 
Customise and upgrade your heroes, starfighters or troopers - each with unique abilities to exploit in battle. Ride tauntauns or take control of tanks and speeders. Use the Force to prove your worth against iconic characters like Kylo Ren, Darth Maul or Han Solo, as you play a part in a gaming experience inspired by forty years of timeless Star Wars films.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/l0u3uqmnnj8ws9ysm67k.jpg"
                },
                new Game
                {
                    Title = @"Porno Studio Tycoon",
                    Summary =
                        @"Business simulator with rich economic model (markets with shortages and surpluses, websites with black hat SEO, etc.), flexible configuration of movie production, complex casting, two modes of shooting (fast and detailed ones) and other features. Beautiful graphics and no sexually explicit content.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/eku1gg56ltnfucepgqny.jpg"
                },
                new Game
                {
                    Title = @"Superfighters Deluxe",
                    Summary =
                        @"Superfighters Deluxe is a multiplayer 2D action game where little flat-headed men fight to the death in small and highly destructible arenas. Surviving each round takes skill, strategy and luck.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/zbvnvg66mwsqt52fnfyk.jpg"
                },
                new Game
                {
                    Title = @"The Evil Within 2",
                    Summary =
                        @"The Evil Within 2 is the latest evolution of survival horror. Detective Sebastian Castellanos has lost it all. But when given a chance to save his daughter, he must descend once more into the nightmarish world of STEM. 
 
Horrifying threats emerge from every corner as the world twists and warps around him. Will Sebastian face adversity head on with weapons and traps, or sneak through the shadows to survive.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/qouzvoeaw7yrsomkm10b.jpg"
                },
                new Game
                {
                    Title = @"Oppai Slider 2",
                    Summary = @"",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/nkugb4uvps5dzccb1wpl.jpg"
                },
                new Game
                {
                    Title = @"Villagers",
                    Summary =
                        @"Villagers is a beautifully illustrated and richly detailed town-building game where you build a thriving community using the people and resources around you. Success or failure depends on your ability to create a town that can grow and prosper, and overcome the harsh realities of medieval life!",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/aooqizxhppovwmuyfkql.jpg"
                },
                new Game
                {
                    Title = @"Spintires: MudRunner",
                    Summary =
                        @"Like Spintires before it, Spintires: MudRunner puts players in the driver seat and dares them to take charge of incredible all-terrain vehicles, venturing across extreme Siberian landscapes with only a map and compass as guides! This edition comes complete with a brand new Sandbox Map joining the original game&#x27;s 5 environments, a total graphical overhaul, a new Challenge mode with 9 new dedicated maps, 13 new vehicles and other comprehensive improvements.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/vxb8ynuasi02xyqxhbs6.jpg"
                },
                new Game
                {
                    Title = @"A Life in Silk - The First Cumming",
                    Summary =
                        @"A Life in Silk is a highly-interactive visual-novel, that tells the story of a feminine sissy boy, who just recently turned 18 and dreams only of becoming a glamorous T-girl Goddess and rule the Big City with his beauty and never ending sexual appetite.

But while stuck in a small suburban town with his single but very libertine Mommy, he knows that to reach his expensive dream of perfect feminine transformation, he will need to seduce as many Sugar Daddies as he can with his advanced oral skills and erotically charge fashion sense, in hopes they will sponsor his transformation.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/oo0dqt8ollefvigrr6bj.jpg"
                },
                new Game
                {
                    Title = @"Xenoblade Chronicles 2",
                    Summary =
                        @"As the giant beasts march toward death, the last hope is a scavenger named Rex—and Pyra, a living weapon known as a Blade. Can you find the fabled paradise she calls home? Command a group of Blades and lead them to countless strategic victories before the world ends. 
 
Each Titan hosts its own distinct cultures, wildlife, and diverse regions to explore. Search the vast open areas and labyrinthine corridors for treasure, secret paths, and creatures to battle and index. 
 
During these escapades you&#x27;ll get to know a large cast of eclectic characters, including the weaponized life forms known as Blades. Gather these allies, bond with them to increase their power, and utilize their special ARTS to devastate enemies. But to save the world of Alrest, you must first demystify its cloudy past. 
 
A new story in the Xenoblade Chronicles series 
 
The next adventure is on the Nintendo Switch console—set on the backs of colossal, living Titans. 
 
Discover each Titan’s diverse regions, culture, wildlife, equipment, and hidden secrets. 
 
Find, bond with, and command weaponized life forms known as Blades to earn abilities and enhance them. 
 
Uncover the history of Alrest and the mystery of its endless ocean of clouds.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/anfq8bz4kprzv8drlx8l.jpg"
                },
                new Game
                {
                    Title = @"Ashen",
                    Summary =
                        @"Ashen is an action RPG about a wanderer in search of a place to call home. There is no sun and the natural light that exists comes from eruptions that cover the land in ash. This is a world where nothing lasts, no matter how tightly you cling to it. 
 
At its core, Ashen is about forging relationships. 
Players can choose to guide those they trust to their camp, encouraging them to rest at the fire and perhaps remain. People you meet out in the world will have unique skills and crafting abilities to bolster your chances of survival. 
 
Together, you might just stand a chance.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/iwbh1uu5zbreqwrk7hlr.jpg"
                },
                new Game
                {
                    Title = @"Earthlock: Festival of Magic",
                    Summary =
                        @"An original turn-based role-playing game set in a world of machines and magic, a world that stopped spinning thousands of years ago. 
 
Rich, non-linear story 
Turn-based combat (No Active Time Battle) 
Combat pairs (Allows more variations to your battle team) 
Grow your own ammunition (Organic crafting) 
Build and improve your home base 
Environmental Puzzles 
Gorgeous overworld with a retro feel 
No random encounters (Monsters visible at all times) 
Play as Male or Female protagonist (You can switch at any time)",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/g0whm2zpztk4g3mwpzo4.jpg"
                },
                new Game
                {
                    Title = @"Masochisia",
                    Summary =
                        @"A young man discovers through a series of hallucinations that he will grow up to become a violent psychopath. How will he respond to these revelations? Can he change his fate? Can you even... change fate...",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/mftzxbt2mmh1bufp3kal.jpg"
                },
                new Game
                {
                    Title = @"Far Cry 5",
                    Summary =
                        @"Welcome to Hope County, Montana, land of the free and the brave, but also home to a fanatical doomsday cult known as The Project at Eden’s Gate that is threatening the community&#x27;s freedom. Stand up to the cult’s leader, Joseph Seed and the Heralds, and spark the fires of resistance that will liberate the besieged community.  
  
In this expansive world, your limits and creativity will be tested against the biggest and most ruthless baddest enemy Far Cry has ever seen. It’ll be wild and it’ll get weird, but as long as you keep your wits about you, the residents of Hope County can rest assured knowing you’re their beacon of hope.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/cuwotikeyasdnpthudjf.jpg"
                },
                new Game
                {
                    Title = @"Gold Rush: The Game",
                    Summary =
                        @"Become the gold miner. Work hard, dig deep, explore the world, and you’ll become the wealthiest man in Alaska. Use a variety of highly-detailed machines to find as much gold as you can.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/rjgdxrtiqrp9viiza6j5.jpg"
                },
                new Game
                {
                    Title = @"The Legend of Queen Opala",
                    Summary = @"",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/itnqsuynccjd08wk4fyz.jpg"
                },
                new Game
                {
                    Title = @"Wild Terra",
                    Summary =
                        @"It is action-RPG and sandbox hybrid with building, crafting, gathering, farming and land claiming elements. There is no NPCs in game so the only way to get something is to create it by yourself or trade from other players... or take it with brutal force. However we understand that not every one have enough time to &quot;live&quot; in game doing everything by their selves that is why all game processes are boosted to make game a little bit casual.

We can say this about your character development as well. It is very boring to level up your character to XX-level just to take a good sword in hands and start to fight. There would be leveling anyway however it would grant you small additional benefits in combats but not major domination.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/ezzt8evn8vgzvercgaxv.jpg"
                },
                new Game
                {
                    Title = @"Pyre",
                    Summary =
                        @"Pyre is a party-based RPG in which you lead a band of exiles to freedom through ancient competitions spread across a vast, mystical purgatory. Who shall return to glory, and who shall remain in exile to the end of their days?",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/s8puinmexsgm8cfvipye.jpg"
                },
                new Game
                {
                    Title = @"SchoolMate 2",
                    Summary = @"The sequel to Illusion soft Schoolmate series.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/zrac3iilq0inlirpxrdv.jpg"
                },
                new Game
                {
                    Title = @"The Last of Us: Part II",
                    Summary =
                        @"Set 5 years after the events of the last of us, Joel and Ellie return on their journey through the ruined cities of America, their path ahead of them will be unfold.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/murzziwvvmzacglj5ch5.jpg"
                },
                new Game
                {
                    Title = @"RIOT - Civil Unrest",
                    Summary =
                        @"As civil crisis deepens and inequality tears the very fabric of society the discontentment of the masses manifests itself in violent public disturbances and civil disorder. Play as the police or the angry horde as RIOT – Civil Unrest places you in some of the world’s most fractious disputes.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/cdfsdijmouaxz7jnx8bl.jpg"
                },
                new Game
                {
                    Title = @"Red Dead Redemption 2",
                    Summary =
                        @"Developed by the creators of Grand Theft Auto V and Red Dead Redemption, Red Dead Redemption 2 is an epic tale of life in America’s unforgiving heartland. The game&#x27;s vast and atmospheric world will also provide the foundation for a brand new online multiplayer experience.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/zf68w0klaobnok5nyulk.jpg"
                },
                new Game
                {
                    Title = @"Caravan",
                    Summary =
                        @"Many myths and legends have been woven about the Arabian Peninsula. One of these legends tells of Iram, City of Pillars, and its exceptional destiny. 
Being the heir to the throne you lived a life of splendor and never worked one day of physical labor – until one day, the winds of fate turned. 

Days passed and the storm did not fade, if anything its strength and ferocity only grew. You would do anything to bring back only a spark of your mother&#x27;s joy. And so, one night, when the kingdom sleeps and the moon smiles, you embark on a journey … 

Caravan combines strategy with RPG elements resulting in a trading and exploration game packed with suspense and challenges. In a pre-medieval Oriental setting players will send their caravan from town to town. On their way, they will experience dangerous, mystical adventures, embark on rewarding quests in towns, and fight against dangerous bandits, beasts, ghoulish creatures and djinns.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/f98wqaqj5e05b1dfxd7z.jpg"
                },
                new Game
                {
                    Title = @"Impact Winter",
                    Summary = @"In 30 days, help is coming...       
       
A mysterious radio transmission claims that help is inbound. You are Jacob Solomon: leader of a makeshift team trying to survive the aftermath of a devastating asteroid collision.  The world you once knew is no more – buried deep beneath the constant snowfall.       
       
Your goal: keep your companions alive until rescue.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/duf8ynjzw9umyejj2kvw.jpg"
                },
                new Game
                {
                    Title = @"Basement",
                    Summary =
                        @"Basement is a strategy game, where you play as a desperate scientist who chose the wrong path in his life. That path seemed easy, but turned into a deadly one. You have no choice but to build the most effective enterprise and stay alive in a cruel world of illegal business.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/ruhw3cmmk0jkechnezw8.jpg"
                },
                new Game
                {
                    Title = @"Ostriv",
                    Summary =
                        @"Ostriv is a single-player strategy game in wich you build and manage cities in late pre-industrial era. 
The events take place on a fictional island, where the player despite all troubles has to build a prospering state.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/o7v5lar6vbdkpjqtco7p.jpg"
                },
                new Game
                {
                    Title = @"Vestige of the Past",
                    Summary =
                        @"Vestige of the Past is a an open world game in which you are exploring an immersive world of alternative presence and trying to survive in an almost familiar but oddly different place. What is behind that contrast between what your eyes are telling you and your gut feeling? Well you will have more pressing matters to worry about at the beginning.  
  
First you will need to learn how to survive and make decisions that you might not be proud of. Or perhaps you will take such decisions you won’t need to be secretive about. It’s all up to you. Either way, you will be the one who will have to deal with the consequences.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/bztl1sg1cargsk2qbyy0.jpg"
                },
                new Game
                {
                    Title = @"Hello, Neighbor!",
                    Summary =
                        @"Hello Neighbor is a stealth horror game about sneaking into your neighbor&#x27;s house to figure out what horrible secrets he&#x27;s hiding in the basement. You play against an advanced AI that learns from your every move. Really enjoying climbing through that backyard window? Expect a bear trap there. Sneaking through the front door? There&#x27;ll be cameras there soon. Trying to escape? The Neighbor will find a shortcut and catch you.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/tyelx5vyuefiuff0gqai.jpg"
                },
                new Game
                {
                    Title = @"Rise &amp; Shine",
                    Summary =
                        @"Rise is a small kid of Gamearth, the world where the classic videogame characters live. He finds himself lost in the middle of a war against the Space Grunts, the bald muscular soldiers with big guns that just invaded his world. Only with the help of the legendary gun, Shine, he’ll be able to stay alive and just maybe, incredibly, save his planet from the invaders. 
 
The game mixes pure shooting arcade with the use of different bullets to solve all the situations Rise will find on his path. Think of a more arcadey Another World, also with a very tight relationship between gameplay and story.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/m3pcyvvbezj3fbnxsofm.jpg"
                },
                new Game
                {
                    Title = @"Startup Company",
                    Summary =
                        @"Startup Company is a business simulation sandbox game. You play as the CEO of a newly formed software company. Your job is to either complete client contracts to make money, or build your very own products.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/ohi340su1nsn4yoa7d9y.jpg"
                },
                new Game
                {
                    Title = @"House of Caravan",
                    Summary =
                        @"Taking place in a single mansion in Candlewood, northeast USA, in the early 20th Century, House of Caravan is a sinister adventure filled with dark secrets and vexing puzzles.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/zrm2ypdvwyllyjmrk59f.jpg"
                },
                new Game
                {
                    Title = @"Anthem",
                    Summary =
                        @"Anthem is a shared-world action RPG, where players can delve into a vast landscape teeming with amazing technology and forgotten treasures. This is a world where Freelancers are called upon to defeat savage beasts, ruthless marauders, and forces plotting to conquer humanity.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/f3ikxckp72fwfqottjiu.jpg"
                },
                new Game
                {
                    Title = @"Fortnite",
                    Summary =
                        @"Fortnite is the living, action building game from the developer formerly known as Epic MegaGames. You and your friends will lead a group of Heroes to reclaim and rebuild a homeland that has been left empty by mysterious darkness only known as &quot;the Storm&quot;. 
 
Band together online to build extravagant forts, find or build insane weapons and traps and protect your towns from the strange monsters that emerge during the Storm. In an action experience from the only company smart enough to attach chainsaws to guns, get out there to push back the Storm and save the world. And don&#x27;t forget to loot all the things.",
                    ImageUrl = @"https://images.igdb.com/igdb/image/upload/t_cover_big/j6cmfwwecqcqzft5ehvq.jpg"
                },
            };
        }
    }
}
