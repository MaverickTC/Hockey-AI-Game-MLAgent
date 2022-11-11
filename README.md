# Project

Air Hockey game AI made with the Unity and MLAgent.

## Air Hockey
<img src="https://github.com/MaverickTC/HockeyGameAI/blob/main/GitHubResources/Images/Image1.png" width=25% height=25%>

### Project Overview
Aimed to achieve a fully autonomous control of the puck to avoid getting scored goal by our rival. The project also contributes for me to have knowledge about the ML Agent.

Inputs: (Relative value based on the x and y position of the ball, speed of the ball at the x axis, a bool that is true if the ball is close to wall at the left and the right.)

Targets: (a x position of the pucks which is between -1 and 1)

Stretch goal: Getting optimized towards scoring a goal to our rival in addition to defending. 


Used Unity 2021.3.6 for development, MLAgent 2.0.1 for AI.
Coded the collision mechanics entirely by myself to make sure that it does not cost a lot of performance and therefore slow training speed.

### Training Process
Training took around 1 hour and 15 million step, as a result the agents were almost invincible.




![Alt Text](https://github.com/MaverickTC/HockeyGameAI/blob/a805bf3994ba20c2bfbf7e7b52c0939d64d3fe8f/Resources/Videos/ezgif-4-9b2d8be1c2.gif)
