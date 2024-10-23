Final Project

Juan Pablo Calvo Franco
April 6th/2022

PLEASE JUMP TO TEST BRANCH
Recommended resolution: 1024 x 768

The purpose of this game is for players to do some critical thinking. The way this is achieved is through the stealth aspect of the game. You have to hide behind objects
in order to not get noticed by enemies. You have to wait until they are not looking to get out of cover and continue. If you get caught, there is another change to outsmart
the AI by "Decieving" them. This is done via a conversation with the enemy. If you choose the right answers depending on the enemy's behaviour, you will be able to continue.
Otherwhise, you will be caught and will have to start the level again.

Known Issues:

The only unintentional issue is the following: Once you "Decieve" an enemy, their text is meant to show for 4 seconds so you can read their final reply.
But if another enemy detects you while this is happening, the new enemy's dialogue displays. This is fine, I wanted it thise way BUT it keeps counting down the 4 seconds
before the enemy dialogue is revealed, therefore making the first line of the other enemy dissapear.

Potential future enhancements:

- Lockpicking mechanic for all doors
- Add more than one type of enemy that can visually show his viewing distance
- Add a score system
- Finish the "story"

Self eval:

Overall, most things went according to plan. I was able to stay on-schedule throughout the making of this project. The only thing that I did not get to add to the game was
the lockpicking mechanic. This is due to the complexity and need for graphics that it would require. I decided that my time was better used towards fixing bugs and continuing
the core game mechanics. If I were to do this again, I could've spent less time changing my scripts, thinking that they were the cause of the error when in fact a lot of my
errors were fixable through the inspector. I also would've made the Deceit system find the TMPUGUI objects by itself instead of serializing the fields and having to drag them
in manually for each level. The biggest problem I has was that an object reference was null and not null at the same time. It took me about an entire class to figure out 
that a stray game object that had the same serialized field was missing the reference. I first identified the error and what causes them. Null references are ALWAYS when
a required object is not attached somewhere. I then checked the serialized fields of every object in my scene. Even the canvas... Which was where it was! It took me that
long because I never thought of looking for it in the Canvas. I deleted the object (It was not necessary) and my program worked!If I were to do this app again, I wish
I knew how easy it is to animate using the animation tools. I wasted a class doing code for animation, which didn't work. So I decided to teach myself the editing tools
which made my animations MUCH easier and better. I believe I should earn back marks
because of the tiny details I included to make my app work better for the user. Such as: Making it so that only one enemy can detect you at a time, the tutorial level.
Also all the love I put into my project by adding different behaviours for enemies. Making the game a little harder but much more interesting. Making the levels myself
instead of making a game that just instantiates new things randomly.

Thank you for playing my game, I had lots of fun making it.