using System;
using System.Collections.Generic;

public class TaskPool
{

    /* 
     * stores the keys (to the tasks), the array represents the Health Stats + Performing time, the index goes like this:
     * brain = 0
     * immune = 1
     * bones = 2
     * muscle = 3
     * heart = 4
     * mood = 5
     
     * performing time = 6     
     * timer = 7
     
     * medicine = 8
     * food = 9
     * water = 10
     * research = 11
    */
    
    public static Dictionary<int, double[]> TaskStats = new Dictionary<int, double[]>
    {
            { 0, new double[] {15,	60,	12,	40,	15,	200,	2,	1,0,	-5,	-2,	0 } },
            { 1, new double[] {41.666,	31.25,	3.472,	10.416,	5.208,	104.166,	2,	0,0,	0,	0,	0} },
            { 2, new double[] {0,	0,	0,	0,	0,	300,	2,	2,0,	0,	0,	0} },
            { 3, new double[] { 41.666,	31.25,	1,	-15,	10.416,	208.333,	16,	30,0,	0,	0,	0} },
            { 4, new double[] { 50,	0,	0,	0,	0,	175,	1,	0,0,	0,	0,	0} },
            { 5, new double[] { 50,	0,0	,0,	15,	150	,1,	0,0	,0,	0,	0} },
            { 6, new double[] { 75,	0,	0,	0,	0,	-150,	1,	0,0,	0,	0,	0} },
            { 7, new double[] { 70,	0,	0,	0,	0,	220,	1,	0,0	,0,	0,	0} },
            { 8, new double[] { 0,	0,	0,	0,	0,	300,	2,	0,0,	0,	0,	0} },
            { 9, new double[] { 0,	0,	0,	0,	0,	500,	2,	1,0,	0,	0,	0} },
            { 10, new double[] { 250,	15,	0,	-15,	0,	90,	1,	0,0,	0,	0,	0} },
            { 11, new double[] { 0,	-10,	0,	0,	0,	300,	1,	0,0,	0,	0,	25} },
            { 12, new double[] { 0,	0,	0,	0,	0,	300,	1,	0,0	,0	,0	,25} },
            { 13, new double[] {0,	0,	0,	0,	0,	105,	1,	4,0,	0,	2,	5} },
            { 14, new double[] {0,	0,	0,	0,	0,	180,	1,	0,0,	0,	0,	0} },
            { 15, new double[] { 0,	0,	0,	0,	0,	200,	1,	0,0,	0,	0	,0} },
            { 16, new double[] { 0,	0,	0	,0	,0,	500,	2,	0,0,	0,	0,	0} },
            { 17, new double[] { 0,	0,	0,	0,	0,	0,	0	,0,0,	0,	0,	0} },    // this is Go to _area  DOES THIS MAKE ANY SENCE????
            { 18, new double[] {  0,	0,	0,	0,	0,	0,	0	,0,0,	0,	0,	0} },   // Idle  
            { 19, new double[] { 0,	0,	0,	0,	0,	175,	1,	12,0,	0,	-5,	0} },
            { 20, new double[] { 0,	0,	0,	0,	0,	300,	2,	48,0,	50,	0,	25} },
            { 21, new double[] { 0,	0	,0	,0,	0,	50,	1,	48,0,	0,	0,	100} },
            { 22, new double[] { 0	,30,	10,	100	,35,	70,	4,	4,0	,0,	0,	0} },
            { 23, new double[] { 400,	0,	0,	0,	0,	0,	1,	2,0	,0,	0,	0} },
            { 24, new double[] {41.666,	31.25,	3.472,	10.416,	5.208,	104.166,	2,	48,0,	0,	0,	0} },
            { 25, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 26, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 27, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 28, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 29, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 30, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 31, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 32, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 33, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0,	0,	0,	250} },
            { 34, new double[] { 0,	0,	0,	0,	0,	0,	1,	1,0,	0,	0,	350} },
            { 35, new double[] { 0,	250,	100,	0,	0,	0,	1,	48,-50,	0,	0,	0} },
            { 36, new double[] { 5000,	5000,	0,	750,	1250,	0,	1,	336,-100,	0,	0,	0} },
            { 37, new double[] { 0,	0,	0,	0,	0,	230,	3,	24,0,	0,	20,	0} },
            { 38, new double[] { 300,	0,	0,	0,	0,	150,	2,	0,0,	0,	0,	0} },
            { 39, new double[] {0,	0,	0,	0,	0,	0,	2,	0,0,	0,	0,	0} }, //Fix broken Equipment. (if there is)
            { 40, new double[] { 50,	0,	0,	0,	0,	0,	3,	1,0,	0,	0,	100} }, //Server OS update.  /R+
            { 41, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, //Research of Brain space troubles (avatar with low stat required) /R+++
            { 42, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, //Research of Bones space troubles (avatar with low stat required) /R+++
            { 43, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, //Research of Muscle space troubles (avatar with low stat required) /R+++
            { 44, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, // Research of Immune space troubles (avatar with low stat required) /R+++
            { 45, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, // Research of Heart space troubles (avatar with low stat required) /R+++
            { 46, new double[] { 0,	0,	0,	0,	0,	0,	4,	3,0	,0,	0,	500} }, // Research of Mental space troubles (avatar with low stat required) /R+++
            { 47, new double[] { 666.666,	0,	0,	0,	0,	0,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Brain special medication arrangements (in case of low health, two).
            { 48, new double[] { 0,	500,	0,	0,	0,	0,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Immune special medication arrangements (in case of low health, two).
            { 49, new double[] { 0,	0,	55.555,	0,	0,	0,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Bones special medication arrangements (in case of low health, two).
            { 50, new double[] { 0,	0,	0,	166.66,	0,	0,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Muscle special medication arrangements (in case of low health, two).
            { 51, new double[] { 0,	0,	0,	0,	83.333,	0,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Heart special medication arrangements (in case of low health, two).
            { 52, new double[] { 0,	0,	0,	0,	0,	1666.666,	5,	24,-1000,	0,	0,	0} }, //Visit a doctor for Mood special medication arrangements (in case of low health, two).
    };
    
    /*
0	Grab a food /F-
1	Meditation
2	Play games
3	Sleep
4	Chat to _smn
5	Flirt to _smn
6	Argue to _smn
7	Joke to _smn
8	Watch TV-show
9	Call to Earth
10	Chill 
11	Check out animal sample /R+
12	Check out veggies /R+
13	Toilet /W+
14	Check out radiation shield
15	Watch the space in observing room
16	Individual realisation: Programming/ Drawing/ Play piano/ Take photos
17	Go to _area
18	Idle
19	Feed veggies /W-
20	Gather veggies /F+
21	Blood test (stress hormone, sugar and calcium level, etc) /R+ (requires two)
22	Fitness
23	Exercising brain and eyes
24	Medical examination with doctor (requires doctor)
25	Planned research for observing Solar orbital system, solar flares /R++
26	Planned research for animal genome /R++
27	Planned research for veggies /R++
28	Planned research for body with ultrasound /R++ (requires two)
29	Planned research for X-ray /R++ (requires two)
30	Planned research of blood and urine /R++ (requires two)
31	Planned research for medication or virus reaction /R++ (requires two)
32	Planned research for Mars atmosphere, soil, landing and other conditions
33	Planned research for energy saving /R++
34	Make other Avatar an injection for research /R++
35	Take everyday vitamins and medicine
36	Take everyweek vitamins and medicine
37	Use IVGEN for fine water making /W++
38	Read a book
39	Fix broken Equipment. (if there is)
40	Server OS update. (after several researches) /R+
41	Research of Brain space troubles (avatar with low stat required) /R+++
42	Research of Bones space troubles (avatar with low stat required) /R+++
43	Research of Muscle space troubles (avatar with low stat required) /R+++
44	Research of Immune space troubles (avatar with low stat required) /R+++
45	Research of Heart space troubles (avatar with low stat required) /R+++
46	Research of Mental space troubles (avatar with low stat required) /R+++
*/
}
