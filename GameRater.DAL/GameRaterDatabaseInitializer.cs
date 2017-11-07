using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRater.DAL.Models;

namespace GameRater.DAL
{
    public class GameRaterDatabaseInitializer : DropCreateDatabaseAlways<GameRaterContext>
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
                    ImageUrl = "/Content/cover-images/call-of-duty-wwii.jpg"
                },
                new Game
                {
                    Title = @"Super Mario Odyssey",
                    Summary =
                        @"The game has Mario leaving the Mushroom Kingdom to reach an unknown open world-like setting, like Super Mario 64 and Super Mario Sunshine.",
                    ImageUrl = "/Content/cover-images/super-mario-odyssey.jpg"
                },
                new Game
                {
                    Title = @"Middle-earth: Shadow of War",
                    Summary =
                        @"Go behind enemy lines to forge your army, conquer Fortresses and dominate Mordor from within. Experience how the award winning Nemesis System creates unique personal stories with every enemy and follower, and confront the full power of the Dark Lord Sauron and his Ringwraiths in this epic new story of Middle-earth.",
                    ImageUrl = "/Content/cover-images/middle-earth-shadow-of-war.jpg"
                },
                new Game
                {
                    Title = @"Assassin’s Creed: Origins",
                    Summary =
                        @"For the last four years, the team behind Assassin’s Creed IV Black Flag has been crafting a new beginning for the Assassin’s Creed franchise. 
 
Set in Ancient Egypt, players will journey to the most mysterious place in history, during a crucial period that will shape the world and give rise to the Assassin’s Brotherhood. Plunged into a living, systemic and majestic open world, players are going to discover vibrant ecosystems, made of diverse and exotic landscapes that will provide them with infinite opportunities of pure exploration, adventures and challenges. 
 
Powered by a new fight philosophy, Assassin&#x27;s Creed Originsembraces a brand new RPG direction where players level up, loot, and choose abilities to shape and customize their very own skilled Assassin as they grow in power and expertise while exploring the entire country of Ancient Egypt.",
                    ImageUrl = "/Content/cover-images/assassins-creed-origins.jpg"
                },
                new Game
                {
                    Title = @"Destiny 2",
                    Summary =
                        @"In Destiny 2, the last safe city on Earth has fallen and lays in ruins, occupied by a powerful new enemy and his elite army, the Red Legion. Every player creates their own character called a “Guardian,” humanity’s chosen protectors. As a Guardian in Destiny 2, players must master new abilities and weapons to reunite the city’s forces, stand together and fight back to reclaim their home.  
  
In Destiny 2 players will answer this call, embarking on a fresh story filled with new destinations around our solar system to explore, and an expansive amount of activities to discover. There is something for almost every type of gamer in Destiny 2, including gameplay for solo, cooperative and competitive players set within a vast, evolving and exciting universe.",
                    ImageUrl = "/Content/cover-images/destiny-2.jpg"
                },
                new Game
                {
                    Title = @"Sonic Forces",
                    Summary =
                        @"The game follows Sonic the Hedgehog as a member of a resistance force against Doctor Eggman, who has taken over the world with the help of his robot army and a mysterious new villain known as Infinite. Gameplay is similar to Sonic Generations with players controlling &quot;Classic&quot; and &quot;Modern&quot; versions of the titular character; the former plays from a 2.5D side-scrolling view reminiscent of the original Sonic games on the Sega Genesis, while the latter uses three-dimensional gameplay similar to Sonic Unleashed and Sonic Colors. In addition to the two Sonics, Sonic Forces also introduces a third gameplay mode featuring the &quot;Avatar&quot;, the player&#x27;s own custom character.",
                    ImageUrl = "/Content/cover-images/sonic-forces.jpg"
                },
                new Game
                {
                    Title = @"Monster Hunter: World",
                    Summary =
                        @"Monster Hunter: World sees players take on the role of a hunter that completes various quests to hunt and slay monsters within a lively living and breathing eco-system full of predators…. and prey. In the video you can see some of the creatures you can expect to come across within the New World, the newly discovered continent where Monster Hunter: World is set, including the Great Jagras which has the ability to swallow its prey whole and one of the Monster Hunter series favourites, Rathalos. 
 
Players are able to utilise survival tools such as the slinger and Scoutfly to aid them in their hunt. By using these skills to their advantage hunters can lure monsters into traps and even pit them against each other in an epic fierce battle. Can our hunter successfully survive the fight and slay the Anjanath? He’ll need to select his weapon choice carefully from 14 different weapon classes and think strategically about how to take the giant foe down. Don’t forget to pack the camouflaging ghillie suit!",
                    ImageUrl = "/Content/cover-images/monster-hunter-world.jpg"
                },
                new Game
                {
                    Title = @"Pokémon Ultra Sun",
                    Summary =
                        @"&quot;Take on the role of a Pokémon Trainer and uncover new tales, and unravel the mystery behind the two forms reminiscent of the Legendary Pokémon. With new story additions and features this earns Pokémon™ Ultra Sun and Pokémon Ultra Moon the name &quot;Ultra!&quot; Another adventure is about to begin! 
 
New Pokémon forms have been discovered in the Aloha region in Pokémon Ultra Sun and Pokémon Ultra Moon! These forms are reminiscent of the Legendary Pokémon Solgaleo, Lunala, and Necrozma, first revealed in Pokémon Sun and Pokémon Moon. Head out on an epic journey as you solve the mystery behind these fascinating Pokémon! In this expanded adventure, get ready to explore more of the Alola region, catch more amazing Pokémon, and battle more formidable foes in Pokémon Ultra Sun and Pokémon Ultra Moon!&quot;",
                    ImageUrl = "/Content/cover-images/pokemon-ultra-sun.jpg"
                },
                new Game
                {
                    Title = @"WWE 2K18",
                    Summary =
                        @"This latest entry in 2k Sports WWE series boasts a next generation graphics engine, the largest roster of any WWE game before it with the rosters updated gimmick sets and show stylings to closely resembles the current TV product, and the first WWE 2k only be released on current generation hardware. 

Seth Rollins was revealed to be the cover star, and the game&#x27;s slogan is &quot;Be Like No One.&quot;",
                    ImageUrl = "/Content/cover-images/wwe-2k18.jpg"
                },
                new Game
                {
                    Title = @"South Park: The Fractured But Whole",
                    Summary =
                        @"Players will once again assume the role of the New Kid, and join South Park favorites Stan, Kyle, Kenny and Cartman in a new hilarious and outrageous adventure. This time, players will delve into the crime-ridden underbelly of South Park with Coon and Friends. 
 
This dedicated group of crime fighters was formed by Eric Cartman whose superhero alter-ego, The Coon, is half man, half raccoon. As the New Kid, players will join Mysterion, Toolshed, Human Kite, Mosquito, Mint Berry Crunch and a host of others to battle the forces of evil while Coon strives to make his team the most beloved superheroes in history.",
                    ImageUrl = "/Content/cover-images/south-park-the-fractured-but-whole.jpg"
                },
                new Game
                {
                    Title = @"ELEX",
                    Summary =
                        @"An action, role-playing open world game for PC and Consoles, Elex was developed by Piranha Bytes, creators of the award winning Gothic series and is set in a brand new, post-apocalyptic, Science-Fantasy universe where magic meets mechs. 
 
&quot;Advanced in technology, civilized and with a population of billions, Magalan was a planet looking to the future. Then the meteor hit. 
 
Those who survived are now trapped in a battle to survive, a struggle to decide the fate of a planet. At the center of this fight is the element “Elex”. A precious, limited resource that arrived with the meteor, Elex can power machines, open the door to magic, or re-sculpt life into new, different forms. 
 
But which of these choices should be the future of Magalan? Can technology or magic save this world? Or will this new power destroy all those left alive amongst the ruins?&quot;",
                    ImageUrl = "/Content/cover-images/elex.jpg"
                },
                new Game
                {
                    Title = @"Dead Island 2",
                    Summary =
                        @"Welcome to Zombie California! Slay and survive with style in this co-op playground. Explore the vast Golden State, from lush forests to sunny beaches. Wield a variety of over-the-top, hand-crafted weapons against human and undead enemies. Upgrade your vehicles, grab your friends, and take a permanent vacation to the zombie apocalypse. Paradise meets hell and you are the matchmaker!",
                    ImageUrl = "/Content/cover-images/dead-island-2.jpg"
                },
                new Game
                {
                    Title = @"Wolfenstein II: The New Colossus",
                    Summary =
                        @"Wolfenstein II: The New Colossus is the highly anticipated sequel to the critically acclaimed, Wolfenstein: The New Order developed by the award-winning studio MachineGames. An exhilarating adventure brought to life by the industry-leading id Tech 6, Wolfenstein II sends players to Nazi-controlled America on a mission to recruit the boldest resistance leaders left. Fight the Nazis in iconic American locations, equip an arsenal of badass guns, and unleash new abilities to blast your way through legions of Nazi soldiers in this definitive first-person shooter. America, 1961. The Nazis maintain their stranglehold on the world. You are BJ Blazkowicz, aka “Terror-Billy,” member of the Resistance, scourge of the Nazi empire, and humanity’s last hope for liberty. Only you have the guts, guns, and gumption to return stateside, kill every Nazi in sight, and spark the second American Revolution.",
                    ImageUrl = "/Content/cover-images/wolfenstein-ii-the-new-colossus.jpg"
                },
                new Game
                {
                    Title = @"Middle-earth: Shadow of War - The Desolation of Mordor",
                    Summary = @"TBA",
                    ImageUrl = "/Content/cover-images/middle-earth-shadow-of-war-the-desolation-of-mordor.jpg"
                },
                new Game
                {
                    Title = @"Sky Break",
                    Summary =
                        @"Sky Break is an open-world game on a stormy abandoned planet filled with wild mechas. Learn to master this world and to hack the mechas if you want a chance to survive.",
                    ImageUrl = "/Content/cover-images/sky-break.jpg"
                },
                new Game
                {
                    Title = @"Star Wars Battlefront II",
                    Summary =
                        @"Embark on an endless Star Wars™ action experience from the best-selling Star Wars HD video game franchise of all time. Experience rich multiplayer battlegrounds across all 3 eras - prequel, classic and new trilogy - or rise as a new hero and discover an emotionally gripping single-player story spanning thirty years. 
 
Customise and upgrade your heroes, starfighters or troopers - each with unique abilities to exploit in battle. Ride tauntauns or take control of tanks and speeders. Use the Force to prove your worth against iconic characters like Kylo Ren, Darth Maul or Han Solo, as you play a part in a gaming experience inspired by forty years of timeless Star Wars films.",
                    ImageUrl = "/Content/cover-images/star-wars-battlefront-ii--1.jpg"
                },
                new Game
                {
                    Title = @"The Evil Within 2",
                    Summary =
                        @"The Evil Within 2 is the latest evolution of survival horror. Detective Sebastian Castellanos has lost it all. But when given a chance to save his daughter, he must descend once more into the nightmarish world of STEM. 
 
Horrifying threats emerge from every corner as the world twists and warps around him. Will Sebastian face adversity head on with weapons and traps, or sneak through the shadows to survive.",
                    ImageUrl = "/Content/cover-images/the-evil-within-2.jpg"
                },
                new Game
                {
                    Title = @"Superfighters Deluxe",
                    Summary =
                        @"Superfighters Deluxe is a multiplayer 2D action game where little flat-headed men fight to the death in small and highly destructible arenas. Surviving each round takes skill, strategy and luck.",
                    ImageUrl = "/Content/cover-images/superfighters-deluxe.jpg"
                },
                new Game
                {
                    Title = @"Villagers",
                    Summary =
                        @"Villagers is a beautifully illustrated and richly detailed town-building game where you build a thriving community using the people and resources around you. Success or failure depends on your ability to create a town that can grow and prosper, and overcome the harsh realities of medieval life!",
                    ImageUrl = "/Content/cover-images/villagers.jpg"
                },
                new Game
                {
                    Title = @"Spintires: MudRunner",
                    Summary =
                        @"Like Spintires before it, Spintires: MudRunner puts players in the driver seat and dares them to take charge of incredible all-terrain vehicles, venturing across extreme Siberian landscapes with only a map and compass as guides! This edition comes complete with a brand new Sandbox Map joining the original game&#x27;s 5 environments, a total graphical overhaul, a new Challenge mode with 9 new dedicated maps, 13 new vehicles and other comprehensive improvements.",
                    ImageUrl = "/Content/cover-images/spintires-mudrunner.jpg"
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
                    ImageUrl = "/Content/cover-images/xenoblade-chronicles-2.jpg"
                },
                new Game
                {
                    Title = @"Ashen",
                    Summary =
                        @"Ashen is an action RPG about a wanderer in search of a place to call home. There is no sun and the natural light that exists comes from eruptions that cover the land in ash. This is a world where nothing lasts, no matter how tightly you cling to it. 
 
At its core, Ashen is about forging relationships. 
Players can choose to guide those they trust to their camp, encouraging them to rest at the fire and perhaps remain. People you meet out in the world will have unique skills and crafting abilities to bolster your chances of survival. 
 
Together, you might just stand a chance.",
                    ImageUrl = "/Content/cover-images/ashen--1.jpg"
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
                    ImageUrl = "/Content/cover-images/earthlock-festival-of-magic.jpg"
                },
                new Game
                {
                    Title = @"Masochisia",
                    Summary =
                        @"A young man discovers through a series of hallucinations that he will grow up to become a violent psychopath. How will he respond to these revelations? Can he change his fate? Can you even... change fate...",
                    ImageUrl = "/Content/cover-images/masochisia.jpg"
                },
                new Game
                {
                    Title = @"Far Cry 5",
                    Summary =
                        @"Welcome to Hope County, Montana, land of the free and the brave, but also home to a fanatical doomsday cult known as The Project at Eden’s Gate that is threatening the community&#x27;s freedom. Stand up to the cult’s leader, Joseph Seed and the Heralds, and spark the fires of resistance that will liberate the besieged community.  
  
In this expansive world, your limits and creativity will be tested against the biggest and most ruthless baddest enemy Far Cry has ever seen. It’ll be wild and it’ll get weird, but as long as you keep your wits about you, the residents of Hope County can rest assured knowing you’re their beacon of hope.",
                    ImageUrl = "/Content/cover-images/far-cry-5.jpg"
                },
                new Game
                {
                    Title = @"Gold Rush: The Game",
                    Summary =
                        @"Become the gold miner. Work hard, dig deep, explore the world, and you’ll become the wealthiest man in Alaska. Use a variety of highly-detailed machines to find as much gold as you can.",
                    ImageUrl = "/Content/cover-images/gold-rush-the-game.jpg"
                },
                new Game
                {
                    Title = @"Ostriv",
                    Summary =
                        @"Ostriv is a single-player strategy game in wich you build and manage cities in late pre-industrial era. 
The events take place on a fictional island, where the player despite all troubles has to build a prospering state.",
                    ImageUrl = "/Content/cover-images/ostriv.jpg"
                },
                new Game
                {
                    Title = @"Wild Terra",
                    Summary =
                        @"It is action-RPG and sandbox hybrid with building, crafting, gathering, farming and land claiming elements. There is no NPCs in game so the only way to get something is to create it by yourself or trade from other players... or take it with brutal force. However we understand that not every one have enough time to &quot;live&quot; in game doing everything by their selves that is why all game processes are boosted to make game a little bit casual.

We can say this about your character development as well. It is very boring to level up your character to XX-level just to take a good sword in hands and start to fight. There would be leveling anyway however it would grant you small additional benefits in combats but not major domination.",
                    ImageUrl = "/Content/cover-images/wild-terra.jpg"
                },
                new Game
                {
                    Title = @"The Last of Us: Part II",
                    Summary =
                        @"Set 5 years after the events of the last of us, Joel and Ellie return on their journey through the ruined cities of America, their path ahead of them will be unfold.",
                    ImageUrl = "/Content/cover-images/the-last-of-us-part-ii.jpg"
                },
                new Game
                {
                    Title = @"Pyre",
                    Summary =
                        @"Pyre is a party-based RPG in which you lead a band of exiles to freedom through ancient competitions spread across a vast, mystical purgatory. Who shall return to glory, and who shall remain in exile to the end of their days?",
                    ImageUrl = "/Content/cover-images/pyre.jpg"
                },
                new Game
                {
                    Title = @"RIOT - Civil Unrest",
                    Summary =
                        @"As civil crisis deepens and inequality tears the very fabric of society the discontentment of the masses manifests itself in violent public disturbances and civil disorder. Play as the police or the angry horde as RIOT – Civil Unrest places you in some of the world’s most fractious disputes.",
                    ImageUrl = "/Content/cover-images/riot-civil-unrest.jpg"
                },
                new Game
                {
                    Title = @"Red Dead Redemption 2",
                    Summary =
                        @"Developed by the creators of Grand Theft Auto V and Red Dead Redemption, Red Dead Redemption 2 is an epic tale of life in America’s unforgiving heartland. The game&#x27;s vast and atmospheric world will also provide the foundation for a brand new online multiplayer experience.",
                    ImageUrl = "/Content/cover-images/red-dead-redemption-2.jpg"
                },
                new Game
                {
                    Title = @"Caravan",
                    Summary =
                        @"Many myths and legends have been woven about the Arabian Peninsula. One of these legends tells of Iram, City of Pillars, and its exceptional destiny. 
Being the heir to the throne you lived a life of splendor and never worked one day of physical labor – until one day, the winds of fate turned. 

Days passed and the storm did not fade, if anything its strength and ferocity only grew. You would do anything to bring back only a spark of your mother&#x27;s joy. And so, one night, when the kingdom sleeps and the moon smiles, you embark on a journey … 

Caravan combines strategy with RPG elements resulting in a trading and exploration game packed with suspense and challenges. In a pre-medieval Oriental setting players will send their caravan from town to town. On their way, they will experience dangerous, mystical adventures, embark on rewarding quests in towns, and fight against dangerous bandits, beasts, ghoulish creatures and djinns.",
                    ImageUrl = "/Content/cover-images/caravan.jpg"
                },
                new Game
                {
                    Title = @"Impact Winter",
                    Summary = @"In 30 days, help is coming...       
       
A mysterious radio transmission claims that help is inbound. You are Jacob Solomon: leader of a makeshift team trying to survive the aftermath of a devastating asteroid collision.  The world you once knew is no more – buried deep beneath the constant snowfall.       
       
Your goal: keep your companions alive until rescue.",
                    ImageUrl = "/Content/cover-images/impact-winter.jpg"
                },
                new Game
                {
                    Title = @"Basement",
                    Summary =
                        @"Basement is a strategy game, where you play as a desperate scientist who chose the wrong path in his life. That path seemed easy, but turned into a deadly one. You have no choice but to build the most effective enterprise and stay alive in a cruel world of illegal business.",
                    ImageUrl = "/Content/cover-images/basement.jpg"
                },
                new Game
                {
                    Title = @"Vestige of the Past",
                    Summary =
                        @"Vestige of the Past is a an open world game in which you are exploring an immersive world of alternative presence and trying to survive in an almost familiar but oddly different place. What is behind that contrast between what your eyes are telling you and your gut feeling? Well you will have more pressing matters to worry about at the beginning.  
  
First you will need to learn how to survive and make decisions that you might not be proud of. Or perhaps you will take such decisions you won’t need to be secretive about. It’s all up to you. Either way, you will be the one who will have to deal with the consequences.",
                    ImageUrl = "/Content/cover-images/vestige-of-the-past.jpg"
                },
                new Game
                {
                    Title = @"Hello, Neighbor!",
                    Summary =
                        @"Hello Neighbor is a stealth horror game about sneaking into your neighbor&#x27;s house to figure out what horrible secrets he&#x27;s hiding in the basement. You play against an advanced AI that learns from your every move. Really enjoying climbing through that backyard window? Expect a bear trap there. Sneaking through the front door? There&#x27;ll be cameras there soon. Trying to escape? The Neighbor will find a shortcut and catch you.",
                    ImageUrl = "/Content/cover-images/hello-neighbor.jpg"
                },
                new Game
                {
                    Title = @"Rise &amp; Shine",
                    Summary =
                        @"Rise is a small kid of Gamearth, the world where the classic videogame characters live. He finds himself lost in the middle of a war against the Space Grunts, the bald muscular soldiers with big guns that just invaded his world. Only with the help of the legendary gun, Shine, he’ll be able to stay alive and just maybe, incredibly, save his planet from the invaders. 
 
The game mixes pure shooting arcade with the use of different bullets to solve all the situations Rise will find on his path. Think of a more arcadey Another World, also with a very tight relationship between gameplay and story.",
                    ImageUrl = "/Content/cover-images/rise-and-shine.jpg"
                },
                new Game
                {
                    Title = @"Startup Company",
                    Summary =
                        @"Startup Company is a business simulation sandbox game. You play as the CEO of a newly formed software company. Your job is to either complete client contracts to make money, or build your very own products.",
                    ImageUrl = "/Content/cover-images/startup-company.jpg"
                },
                new Game
                {
                    Title = @"House of Caravan",
                    Summary =
                        @"Taking place in a single mansion in Candlewood, northeast USA, in the early 20th Century, House of Caravan is a sinister adventure filled with dark secrets and vexing puzzles.",
                    ImageUrl = "/Content/cover-images/house-of-caravan.jpg"
                },
                new Game
                {
                    Title = @"Anthem",
                    Summary =
                        @"Anthem is a shared-world action RPG, where players can delve into a vast landscape teeming with amazing technology and forgotten treasures. This is a world where Freelancers are called upon to defeat savage beasts, ruthless marauders, and forces plotting to conquer humanity.",
                    ImageUrl = "/Content/cover-images/anthem.jpg"
                },
                new Game
                {
                    Title = @"Don&#x27;t Knock Twice",
                    Summary =
                        @"Don&#x27;t Knock Twice is a first-person horror game based on a psychologically terrifying urban legend. To save her estranged daughter, a guilt-ridden mother must uncover the frightening truth behind the urban tale of a vengeful, demonic witch. One knock to wake her from her bed, twice to raise her from the dead. 
 
Explore a grand manor house and interact with almost every object you see. To find and save your daughter, you will explore all depths of the manor, searching for hidden clues and using items to fight or escape the terror that surrounds you. 
 
The game is based on the film, Don&#x27;t Knock Twice, starring Katee Sackhoff (Battlestar Galactica) and directed by Caradog James (The Machine).",
                    ImageUrl = "/Content/cover-images/dont-knock-twice.jpg"
                },
                new Game
                {
                    Title = @"Only If",
                    Summary =
                        @"Only If is a surreal first person adventure-puzzle game. You play as Anthony Clyde, who, after a heavy night of partying, wakes up to find himself in an unfamiliar bed with no memory of the previous night&#x27;s events. Unfortunately, escaping these unfamiliar, opulent surroundings will prove to be no easy task, as an unseen, menacing, radio-bound antagonist will stop at nothing to block Anthony&#x27;s path at every turn.",
                    ImageUrl = "/Content/cover-images/only-if.jpg"
                },
                new Game
                {
                    Title = @"The Long Journey Home",
                    Summary =
                        @"The Long Journey Home combines the endless freedom of space with a new open questing system that always leaves you in command. Deliver the stranded Glukkt to his homeworld as he asks, or to your new slaver friends? Attempt to make allies with everyone, or pin your hopes on the tougher races, and hope they never turn on you? Jump by jump, make hard decisions and live with the consequences, in a universe that is never the same twice.",
                    ImageUrl = "/Content/cover-images/the-long-journey-home.jpg"
                },
                new Game
                {
                    Title = @"Totally Accurate Battle Simulator",
                    Summary =
                        @"A physics based medieval battle simulator which lets you pit wacky waving armies against each other. In Totally Accurate Battle Simulator you pit waving arm men against each other and watch them fight it out.",
                    ImageUrl = "/Content/cover-images/totally-accurate-battle-simulator.jpg"
                },
                new Game
                {
                    Title = @"Citadel: Forged With Fire",
                    Summary =
                        @"&quot;Citadel: Forged With Fire is a massive online sandbox RPG with elements of magic, spellcasting and inter-kingdom conflict. As a newly minted apprentice of the magic arts, you will set off to investigate the dangerous world of Ignus. Your goal: create a name for yourself and achieve notoriety and power among the land’s ruling Houses.

You have complete freedom to pursue your own destiny; hatch plots of trickery and deceit to ascend the ranks among allies and enemies, become an infamous hunter of other players, build massive and unique castles, tame mighty beasts to do your bidding, and visit uncharted territories to unravel their rich and intriguing history. The path to ultimate power and influence is yours to choose.&quot;",
                    ImageUrl = "/Content/cover-images/citadel-forged-with-fire.jpg"
                },
                new Game
                {
                    Title = @"Cuphead",
                    Summary =
                        @"Cuphead is a classic run and gun action game heavily focused on boss battles. Inspired by cartoons of the 1930s, the visuals and audio are painstakingly created with the same techniques of the era, i.e. traditional cel animation (hand drawn &amp; hand inked!), watercolor backgrounds, and original jazz recordings. Play as Cuphead or Mugman (in single player or co-op) as you traverse strange worlds, acquire new weapons, learn powerful super moves, and discover hidden secrets. Cuphead is all action, all the time.",
                    ImageUrl = "/Content/cover-images/cuphead.jpg"
                },
                new Game
                {
                    Title = @"The Witcher 3: Wild Hunt",
                    Summary =
                        @"The Witcher: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences. In The Witcher you play as the professional monster hunter, Geralt of Rivia, tasked with finding a child of prophecy in a vast open world rich with merchant cities, viking pirate islands, dangerous mountain passes, and forgotten caverns to explore.",
                    ImageUrl = "/Content/cover-images/the-witcher-3-wild-hunt.jpg"
                },
                new Game
                {
                    Title = @"Life is Feudal: Forest Village",
                    Summary =
                        @"Life is Feudal: Forest Village is RTS city builder game with survival aspects in a realistic harsh medieval world. Shape, build and expand your settlement, grow various food to prevent your villagers from avitaminosis and starvation. Possess them for additional micromanagement or simply to wander around. Become a leader of the newly arrived settlers and lead them to peace and prosperity.",
                    ImageUrl = "/Content/cover-images/life-is-feudal-forest-village.jpg"
                },
                new Game
                {
                    Title = @"Days Gone",
                    Summary =
                        @"Days Gone is an open-world action-adventure game set in a harsh wilderness two years after a devastating global pandemic. Play as Deacon St. John, a Drifter and bounty hunter who rides the broken road, fighting to survive while searching for a reason to live.

At its core, Days Gone is about survivors and what makes them human: desperation, loss, madness, betrayal, friendship, brotherhood, regret, love – and hope. It’s about how even when confronted with such enormous tragedy they find a reason to live. Hope never dies.",
                    ImageUrl = "/Content/cover-images/days-gone.jpg"
                },
                new Game
                {
                    Title = @"Dante&#x27;s Inferno",
                    Summary =
                        @"Dante&#x27;s Inferno is an epic single player, third-person action adventure game inspired by &quot;Inferno&quot;, part one of Dante Alighieri&#x27;s classic Italian poem, &quot;The Divine Comedy.&quot; Featuring nonstop action rendered at 60 frames-per-second, signature and upgradable weapons, attack combos and mana-fueled spells and the choice of punishing or absolving the souls of defeated enemies, it is a classic Medieval tale of the eternal conflict with sin and the resulting horrors of hell, adapted for a new generation and a new medium.",
                    ImageUrl = "/Content/cover-images/dante-s-inferno.jpg"
                },
                new Game
                {
                    Title = @"Life is Strange: Before the Storm",
                    Summary =
                        @"Life is Strange: Before the Storm is a new three part standalone story adventure set three years before the events of the first game. This time play as Chloe Price, a rebel who forms an unlikely friendship with Rachel Amber in dramatic new story in the BAFTA award winning franchise.",
                    ImageUrl = "/Content/cover-images/life-is-strange-before-the-storm.jpg"
                },
                new Game
                {
                    Title = @"Stick Fight: The Game",
                    Summary =
                        @"Stick Fight is a physics-based couch/online fighting game where you battle it out as the iconic stick figures from the golden age of the internet",
                    ImageUrl = "/Content/cover-images/stick-fight-the-game.jpg"
                },
                new Game
                {
                    Title = @"Absolver",
                    Summary =
                        @"Absolver is an online multiplayer combat RPG where players are placed behind the mask of a Prospect under control of the Guides, the new rulers of the fallen Adal Empire, who have placed you here to determine your worth in joining their elite corps of Absolvers.",
                    ImageUrl = "/Content/cover-images/absolver.jpg"
                },
                new Game
                {
                    Title = @"Divinity: Original Sin 2",
                    Summary =
                        @"Divinity: Original Sin 2 is a single- and multiplayer top-down, party-based role-playing game with pen &amp; paper RPG-like levels of freedom.It features turn-based combat, a strong focus on systematic gameplay and a well-grounded narrative.

Divinity: Original Sin 2 is the sequel to the critically acclaimed Divinity: Original Sin, winner of over 150 Game of the Year awards and nominations.",
                    ImageUrl = "/Content/cover-images/divinity-original-sin-2.jpg"
                },
                new Game
                {
                    Title = @"Tears of Avia",
                    Summary =
                        @"Tears of Avia is a turn-based tactical RPG. Play with up to 5 classes and hundreds of skills, finding the best synergy with your party and their skill loadout will mean the difference between success and failure. Run a balanced party or roll nothing but warriors, the choice is yours. With some skills being weapon bound rather than class bound, there are endless possibilities for you to experiment from.",
                    ImageUrl = "/Content/cover-images/tears-of-avia.jpg"
                },
                new Game
                {
                    Title = @"Need For Speed: Payback",
                    Summary =
                        @"&quot;This explosive adventure is filled with intense heist missions, high stakes car battles, epic cop pursuits and jaw dropping set pieces. It’s blockbuster gameplay never before seen from the series, fueled by a gripping story of betrayal and revenge. With Need for Speed: Payback, it’s no longer just about being the first to cross the finish line or racing to prove to be the best, it’s about building the perfect ride, getting behind the wheel and playing out an action driving fantasy.

Set in the underworld of Fortune Valley, players will drive as three distinct characters reunited by a quest for vengeance against The House, a nefarious cartel that rules the city’s casinos, criminals and cops. They will take on a variety of challenges and events as Tyler, the Racer; Mac, the Showman; and Jess, the Wheelman to earn the respect of the underground. Featuring the deepest customization from the series, players can truly craft a personalized and unique ride, or spend hours finding and tuning an abandoned derelict into a supercar. They can then push their cars to the limit and raise the stakes by betting on their own performance, where they can either multiply their winnings or risk losing it all.&quot;",
                    ImageUrl = "/Content/cover-images/need-for-speed-payback.jpg"
                },
                new Game
                {
                    Title = @"The Last of Us",
                    Summary =
                        @"Twenty years after a mutated fungus started turning people all over the world into deadly zombies, humans become an endangered species. Joel, a Texan in his forties with the &quot;emotional range of a teaspoon&quot; (to quote Hermione from Harry Potter), finds himself responsible with the safety of a fourteen year old girl named Ellie whom he must smuggle to a militia group called the Fireflies. And as if the infected aren&#x27;t enough of a hassle, they also have to deal with the authorities who wouldn&#x27;t let them leave the quarantine zone, as well as other survivors capable of killing anyone who might have something useful in their backpacks.",
                    ImageUrl = "/Content/cover-images/the-last-of-us.jpg"
                },
                new Game
                {
                    Title = @"Morphite",
                    Summary =
                        @"Morphite is a stylized FPS sci fi adventure game, inspired by the classics. Research plants and animals, battle hostile entities, and unravel a mystery surrounding a rare material called Morphite.",
                    ImageUrl = "/Content/cover-images/morphite.jpg"
                },
                new Game
                {
                    Title = @"Candle",
                    Summary =
                        @"Candle is an adventure with challenging puzzles. Play as Teku, a young man on a dangerous journey to rescue his tribe&#x27;s shaman from the evil Wakcha-Clan. But the way is littered with sinister traps and difficult obstacles. To master these challenges you need to have keen eyes and a good sense for your environment, or your next step may be your last.

But Teku has a special gift: his left hand is a candle. Let it be a bright beacon to drive off your enemies or to shed light on dark places.
Gorgeous hand-painted watercolor visuals give Candle that special flair, as all backgrounds and characters have been carefully drawn and then scanned, picture after picture. The game consistently feels like a living painting.",
                    ImageUrl = "/Content/cover-images/candle.jpg"
                },
                new Game
                {
                    Title = @"Aven Colony",
                    Summary =
                        @"Aven Colony is a city-building and management sim that tells the story of humanity’s first settlement of an extrasolar world. Land on exotic Aven Prime, where you must construct and maintain the infrastructure and ensure the well-being of your citizens, all while dealing with the often harsh realities of an exotic alien world.

On top of this, you’ll face the greatest challenge of all — keeping your people happy. How will you feed your people? Will you be able to provide them with enough jobs, entertainment, retail outlets, and other services while protecting them from the planet’s many dangers? What social policies will you enact to influence your people? The future of the colony rests on your decisions.",
                    ImageUrl = "/Content/cover-images/aven-colony.jpg"
                },
                new Game
                {
                    Title = @"FIFA 18",
                    Summary =
                        @"Powered by Frostbite™, EA SPORTS™ FIFA 18 blurs the line between the virtual and real worlds, bringing to life the players, teams, and atmospheres that immerse you in the emotion of The World’s Game. The biggest step in gameplay innovation in franchise history, FIFA 18 introduces Real Player Motion Technology, an all-new animation system which unlocks a new level of responsiveness, and player personality – now Cristiano Ronaldo and other top players feel and move exactly like they do on the real pitch. Player Control combined with new Team Styles and Positioning give you the tools to deliver Dramatic Moments that ignite Immersive Atmospheres around the world. The World’s Game also takes you on a global journey as Alex Hunter Returns along with a star-studded cast of characters, including Cristiano Ronaldo and other European football stars. And in FIFA Ultimate Team™, FUT ICONS, featuring Ronaldo Nazário and other football legends, are coming to FIFA 18 on PlayStation 4, Xbox One, and PC when the game launches on September 29, 2017.",
                    ImageUrl = "/Content/cover-images/fifa-18.jpg"
                },
                new Game
                {
                    Title = @"What Remains of Edith Finch",
                    Summary =
                        @"What Remains of Edith Finch is a collection of short stories about a cursed family in Washington State.

Each story offers a chance to experience the life of a different family member with stories ranging from the early 1900s to the present day. The gameplay and tone of the stories are as varied as the family members themselves. The only constants are that each is played from a first-person perspective and that each story ends with that family member&#x27;s death. It&#x27;s a game about what it feels like to be humbled and astonished by the vast and unknowable world around us.

You&#x27;ll follow Edith Finch as she explores the history of her family and tries to figure out why she&#x27;s the last Finch left alive.",
                    ImageUrl = "/Content/cover-images/what-remains-of-edith-finch.jpg"
                },
                new Game
                {
                    Title = @"Quern - Undying Thoughts",
                    Summary =
                        @"Quern is a first person puzzle adventure with captivating story and beautiful graphics. Quern refreshes the genre with flexible gameplay and reuseable puzzle mechanics. The visuals and the music combine traditional and modern elements providing a unique mood for the game.

One of the specialities of Quern is that the tasks to be solved are not managed as separate, individual and sequential units, but as a complex entity, amongst which the players may wander and experiment freely. Often a bad or seemingly irrational result may bring the player closer to the final solution, if those are reconsidered and thought over again later, in the possession of the knowledge gained during the game.",
                    ImageUrl = "/Content/cover-images/quern-undying-thoughts.jpg"
                },
                new Game
                {
                    Title = @"Horizon: Zero Dawn",
                    Summary =
                        @"Horizon Zero Dawn, an exhilarating new action role playing game exclusively for the PlayStation 4 system, developed by the award winning Guerrilla Games, creatos of PlayStation&#x27;s venerated Killzone franchise. As Horizon Zero Dawn&#x27;s main protagonist Aloy, a skilled hunter, explore a vibrant and lush world inhabited by mysterious mechanized creatures.",
                    ImageUrl = "/Content/cover-images/horizon-zero-dawn.jpg"
                },
                new Game
                {
                    Title = @"Tavern Tycoon",
                    Summary =
                        @"Run your fantasy RPG tavern - let travellers take shelter for the night and serve &#x27;em the best mead of their life with a good dose of humor.",
                    ImageUrl = "/Content/cover-images/tavern-tycoon.jpg"
                },
                new Game
                {
                    Title = @"RimWorld",
                    Summary = @"A sci fi colony sim driven by an intelligent AI storyteller.
RimWorld follows three survivors from a crashed space liner as they build a colony on a frontier world at the rim of known space. Inspired by the space western vibe of Firefly, the deep simulation of Dwarf Fortress, and the epic scale of Dune and Warhammer 40,000.

Manage colonists&#x27; moods, needs, thoughts, individual wounds, and illnesses. Engage in deeply-simulated small-team gunplay. Fashion structures, weapons, and apparel from metal, wood, stone, cloth, or exotic, futuristic materials. Fight pirate raiders, hostile tribes, rampaging animals and ancient killing machines. Discover a new generated world each time you play. Build colonies in biomes ranging from desert to jungle to tundra, each with unique flora and fauna. Manage and develop colonists with unique backstories, traits, and skills. Learn to play easily with the help of an intelligent and unobtrusive AI tutor.",
                    ImageUrl = "/Content/cover-images/rimworld.jpg"
                },
                new Game
                {
                    Title = @"Warframe: Plains of Eidolon",
                    Summary =
                        @"For the first time in Warframe history, explore, fight, journey, and fly through the open Landscapes of Planet Earth. Visit the bustling town of Cetus, and meet its scavenger inhabitants, the Ostrons. Protect Cetus and it’s people from the Grineer patrols with parkour, stealth, or by air in your Archwing on the Plains of Eidolon.",
                    ImageUrl = "/Content/cover-images/warframe-plains-of-eidolon.jpg"
                },
                new Game
                {
                    Title = @"Cyberpunk 2077",
                    Summary =
                        @"The upcoming RPG from CD Projekt RED, creators of The Witcher series of games, based on the Cyberpunk 2020 tabletop RPG created by Mike Pondsmith.",
                    ImageUrl = "/Content/cover-images/cyberpunk-2077.jpg"
                },
                new Game
                {
                    Title = @"Northgard",
                    Summary =
                        @"Northgard is a strategy game based on Norse mythology in which you control a clan of Vikings vying for the control of a mysterious newfound continent.",
                    ImageUrl = "/Content/cover-images/northgard.jpg"
                },
                new Game
                {
                    Title = @"INSIDE",
                    Summary = @"Hunted and alone, a boy finds himself drawn into the center of a dark project.",
                    ImageUrl = "/Content/cover-images/inside.jpg"
                },
                new Game
                {
                    Title = @"Allison Road",
                    Summary =
                        @"Allison Road is a survival horror game developed in Unreal Engine 4, played in first person view with optional Oculus Rift support.

You will take on the role of the unnamed protagonist who wakes up one day without any recollection of prior events. Over the course of five nights It is your objective to uncover the whereabouts of your family, unravel the mysteries of the house, and face off against Lily and other dark entities that are nested deep within the house, while the clock is relentlessly ticking towards 3:00am.

What would you do if you could feel something stalking you in the dark in the safety of your own home?
If you couldn&#x27;t tell what&#x27;s real and what&#x27;s not?

Allison Road combines old-school survival horror and adventure game mechanics with next-gen graphics and optional VR support.

The game was initially developed by one person but then the team slowly grew to its current size of 6 people.",
                    ImageUrl = "/Content/cover-images/allison-road.jpg"
                },
                new Game
                {
                    Title = @"Rusty Lake: Roots",
                    Summary =
                        @"James Vanderboom&#x27;s life drastically changes when he plants a special seed in the garden of the house he has inherited. Expand your bloodline by unlocking portraits in the tree of life.",
                    ImageUrl = "/Content/cover-images/rusty-lake-roots.jpg"
                },
                new Game
                {
                    Title = @"Bubsy: The Woolies Strike Back",
                    Summary =
                        @"&quot;Bubsy the Woolies Strike Back! is an all new Bubsy adventure featuring Bubsy in a bevy of exotic locations as he travels the planet looking for the beloved Golden Fleece.

Bubsy must use all of his classic moves and a few new ones to dodge and out bobcat a battalion of Woolies, not mention the gnarliest UFO bosses to ever grace a Bubsy adventure.

The wisecracking lynx also adds over a 100 new one liners to his lexicon to keep fans guessing what he’ll say next.&quot;",
                    ImageUrl = "/Content/cover-images/bubsy-the-woolies-strike-back.jpg"
                },
                new Game
                {
                    Title = @"Last Day of June",
                    Summary =
                        @"A deep, interactive adventure about love and loss, beautifully depicted and offering an intense cinematic experience. What would you do to save the one you love?",
                    ImageUrl = "/Content/cover-images/last-day-of-june.jpg"
                },
                new Game
                {
                    Title = @"Horizon: Zero Dawn - The Frozen Wilds",
                    Summary =
                        @"The Frozen Wilds contains additional content for Horizon Zero Dawn, including new storylines, characters and experiences in a beautiful but unforgiving new area.",
                    ImageUrl = "/Content/cover-images/horizon-zero-dawn-the-frozen-wilds.jpg"
                },
                new Game
                {
                    Title = @"Last Day on Earth: Survival",
                    Summary =
                        @"Last Day on Earth is a free multiplayer zombie survival strategy game, where all survivors are driven by one target: stay alive and survive as long as you can and shoot walking dead zombies. There is no place left for friendship, love and compassion. A deadly plague pandemic has turned the world into a dead zone. You can trust only yourself in this post apocalyptic world infected with walking dead zombies.",
                    ImageUrl = "/Content/cover-images/last-day-on-earth-survival.jpg"
                },
                new Game
                {
                    Title = @"A Way Out",
                    Summary =
                        @"A Way Out is a couch or online co-op only game where you play the role of one of two prisoners in a daring escape over and beyond the prison walls.

What begins as a thrilling escape quickly turns into an emotional adventure unlike anything seen &amp; played before. A Way Out is a two-player experience. Each player controls one of the main characters, working together to escape the prison and continue beyond into each character’s lives.

It is a game that explores the notion of trust, companionship and facing up to consequences.",
                    ImageUrl = "/Content/cover-images/a-way-out.jpg"
                },
                new Game
                {
                    Title = @"Undertale",
                    Summary =
                        @"A small child falls into the Underground, where monsters have long been banished by humans and are hunting every human that they find. The player controls the child as they try to make it back to the Surface through hostile environments, all the while killing or sparing the monsters they encounter along the way through a turn-based combat system with bullet hell elements and other unconventional game mechanics.",
                    ImageUrl = "/Content/cover-images/undertale.jpg"
                },
                new Game
                {
                    Title = @"Gran Turismo Sport",
                    Summary =
                        @"Welcome to the future of motorsports – the definitive motor racing experience is back and better than ever only on PlayStation 4.

Gran Turismo Sport is the world’s first racing experience to be built from the ground up to bring global, online competitions sanctioned by the highest governing body of international motorsports, the FIA (Federation International Automobile). Create your legacy as you represent and compete for your home country or favorite manufacturer.",
                    ImageUrl = "/Content/cover-images/gran-turismo-sport.jpg"
                },
                new Game
                {
                    Title = @"Stardew Valley",
                    Summary =
                        @"Stardew Valley is an open-ended country-life RPG! You’ve inherited your grandfather’s old farm plot in Stardew Valley. Armed with hand-me-down tools and a few coins, you set out to begin your new life. Can you learn to live off the land and turn these overgrown fields into a thriving home? It won’t be easy. Ever since Joja Corporation came to town, the old ways of life have all but disappeared. The community center, once the town’s most vibrant hub of activity, now lies in shambles. But the valley seems full of opportunity. With a little dedication, you might just be the one to restore Stardew Valley to greatness!",
                    ImageUrl = "/Content/cover-images/stardew-valley.jpg"
                },
                new Game
                {
                    Title = @"The Last Guardian",
                    Summary =
                        @"In a strange and mystical land, a young boy discovers a mysterious creature with which he forms a deep, unbreakable bond. The unlikely pair must rely on each other to journey through towering, treacherous ruins filled with unknown dangers. Experience the journey of a lifetime in this touching, emotional story of friendship and trust.",
                    ImageUrl = "/Content/cover-images/the-last-guardian.jpg"
                },
                new Game
                {
                    Title = @"Half-Life 3",
                    Summary = @"The long awaited final part of the Half-Life saga.",
                    ImageUrl = "/Content/cover-images/half-life-3.jpg"
                },
                new Game
                {
                    Title = @"StarBreak",
                    Summary =
                        @"StarBreak is a unique skill-based action platformer MMO where you explore strange sci-fi worlds alongside dozens of other players, kill legions of dangerous aliens and fight epic boss battles.",
                    ImageUrl = "/Content/cover-images/starbreak.jpg"
                },
            };
        }
    }
}
