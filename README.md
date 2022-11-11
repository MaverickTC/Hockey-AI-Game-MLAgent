

## Air Hockey game AI made with the Unity and MLAgent.

<img align="left" src="https://github.com/MaverickTC/HockeyGameAI/blob/main/GitHubResources/Images/Image1.png" width=25% height=25%>

## Project Overview
Reinforcement Learning is a exciting tool which allows the agents to train by the trial and error method. This method let us to use a power of our computers to come up with a perfect solution.

Aimed to achieve a fully autonomous control of the puck to avoid getting scored goal by our rival. The project also contributes for me to have knowledge about the ML Agent and the reinforcement learning.

Inputs: (Relative value based on the x and y position of the ball, speed of the ball at the x axis, a bool that is true if the ball is close to wall at the left and the right.)

Targets: (a x position of the pucks which is between -1 and 1)

Stretch goal: Getting optimized towards scoring a goal to our rival in addition to defending. 


Used Unity 2021.3.6 for development of the game mechanics and MLAgent 2.0.1 for the AI.

It is trained with the Proximal Policy Optimization (PPO) algorithm which is included at the ML-Agent.

Coded the collision mechanics entirely by myself to make sure that it does not cost a lot of performance and therefore slow training speed.
&nbsp;
## Training Neural Network Instructions
1- [Complete the installation of the required tools.](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md/) 

2- The trainer config file which is included at the repository (trainer_config.yaml) should be moved to the ml-agents root directory.

3- Run the command given at the bottom part. (Running the training)

### Running the training
mlagents-learn trainer_config.yaml --train --run-id=Hockey

### Visualization
tensorboard --logdir results --port 6006

## Training Process
Training took around 1 hour and 15 million step, as a result the agents were almost invincible.

## Sample Output
<img src="https://github.com/MaverickTC/HockeyGameAI/blob/main/GitHubResources/Images/Graph1.png">
<img src="https://github.com/MaverickTC/HockeyGameAI/blob/main/GitHubResources/Images/Graph2.png">



## Gif from the training process
![Alt Text](https://github.com/MaverickTC/HockeyGameAI/blob/a805bf3994ba20c2bfbf7e7b52c0939d64d3fe8f/Resources/Videos/ezgif-4-9b2d8be1c2.gif)
