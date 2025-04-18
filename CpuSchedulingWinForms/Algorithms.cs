using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt16(userInput);
            int arraySize = numberOfProcesses * 2;

            double[] burstTimes = new double[numberOfProcesses];
            double[] waitingTimes = new double[numberOfProcesses];
            string[] outputArray = new string[arraySize];
            double totalWaitingTime = 0.0, averageWaitingTime;
            int processIndex;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    string burstTimeInput =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (processIndex + 1),
                                                       "",
                                                       -1, -1);

                    burstTimes[processIndex] = Convert.ToInt64(burstTimeInput);
                }

                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    if (processIndex == 0)
                    {
                        waitingTimes[processIndex] = 0;
                    }
                    else
                    {
                        waitingTimes[processIndex] = waitingTimes[processIndex - 1] + burstTimes[processIndex - 1];
                        MessageBox.Show("Waiting time for P" + (processIndex + 1) + " = " + waitingTimes[processIndex], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[processIndex];
                }
                averageWaitingTime = totalWaitingTime / numberOfProcesses;
                MessageBox.Show("Average waiting time for " + numberOfProcesses + " processes" + " = " + averageWaitingTime + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt16(userInput);

            double[] burstTimes = new double[numberOfProcesses];
            double[] waitingTimes = new double[numberOfProcesses];
            double[] sortedBurstTimes = new double[numberOfProcesses];
            double totalWaitingTime = 0.0, averageWaitingTime;
            int currentProcess, processIndex;
            double tempBurstTime = 0.0;
            bool processFound = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    string burstTimeInput =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (processIndex + 1),
                                                           "",
                                                           -1, -1);

                    burstTimes[processIndex] = Convert.ToInt64(burstTimeInput);
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    sortedBurstTimes[processIndex] = burstTimes[processIndex];
                }
                for (currentProcess = 0; currentProcess <= numberOfProcesses - 2; currentProcess++)
                {
                    for (processIndex = 0; processIndex <= numberOfProcesses - 2; processIndex++)
                    {
                        if (sortedBurstTimes[processIndex] > sortedBurstTimes[processIndex + 1])
                        {
                            tempBurstTime = sortedBurstTimes[processIndex];
                            sortedBurstTimes[processIndex] = sortedBurstTimes[processIndex + 1];
                            sortedBurstTimes[processIndex + 1] = tempBurstTime;
                        }
                    }
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    if (processIndex == 0)
                    {
                        for (currentProcess = 0; currentProcess <= numberOfProcesses - 1; currentProcess++)
                        {
                            if (sortedBurstTimes[processIndex] == burstTimes[currentProcess] && processFound == false)
                            {
                                waitingTimes[processIndex] = 0;
                                MessageBox.Show("Waiting time for P" + (currentProcess + 1) + " = " + waitingTimes[processIndex], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                burstTimes[currentProcess] = 0;
                                processFound = true;
                            }
                        }
                        processFound = false;
                    }
                    else
                    {
                        for (currentProcess = 0; currentProcess <= numberOfProcesses - 1; currentProcess++)
                        {
                            if (sortedBurstTimes[processIndex] == burstTimes[currentProcess] && processFound == false)
                            {
                                waitingTimes[processIndex] = waitingTimes[processIndex - 1] + sortedBurstTimes[processIndex - 1];
                                MessageBox.Show("Waiting time for P" + (currentProcess + 1) + " = " + waitingTimes[processIndex], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                burstTimes[currentProcess] = 0;
                                processFound = true;
                            }
                        }
                        processFound = false;
                    }
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[processIndex];
                }
                MessageBox.Show("Average waiting time for " + numberOfProcesses + " processes" + " = " + (averageWaitingTime = totalWaitingTime / numberOfProcesses) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] burstTimes = new double[numberOfProcesses];
                double[] waitingTimes = new double[numberOfProcesses + 1];
                int[] priorities = new int[numberOfProcesses];
                int[] sortedPriorities = new int[numberOfProcesses];
                int currentProcess, processIndex;
                double totalWaitingTime = 0.0;
                double averageWaitingTime;
                int tempPriority = 0;
                bool processFound = false;
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    string burstTimeInput =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (processIndex + 1),
                                                           "",
                                                           -1, -1);

                    burstTimes[processIndex] = Convert.ToInt64(burstTimeInput);
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    string priorityInput =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (processIndex + 1),
                                                           "",
                                                           -1, -1);

                    priorities[processIndex] = Convert.ToInt16(priorityInput);
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    sortedPriorities[processIndex] = priorities[processIndex];
                }
                for (currentProcess = 0; currentProcess <= numberOfProcesses - 2; currentProcess++)
                {
                    for (processIndex = 0; processIndex <= numberOfProcesses - 2; processIndex++)
                    {
                        if (sortedPriorities[processIndex] > sortedPriorities[processIndex + 1])
                        {
                            tempPriority = sortedPriorities[processIndex];
                            sortedPriorities[processIndex] = sortedPriorities[processIndex + 1];
                            sortedPriorities[processIndex + 1] = tempPriority;
                        }
                    }
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    if (processIndex == 0)
                    {
                        for (currentProcess = 0; currentProcess <= numberOfProcesses - 1; currentProcess++)
                        {
                            if (sortedPriorities[processIndex] == priorities[currentProcess] && processFound == false)
                            {
                                waitingTimes[processIndex] = 0;
                                MessageBox.Show("Waiting time for P" + (currentProcess + 1) + " = " + waitingTimes[processIndex], "Waiting time", MessageBoxButtons.OK);
                                tempPriority = currentProcess;
                                priorities[currentProcess] = 0;
                                processFound = true;
                            }
                        }
                        processFound = false;
                    }
                    else
                    {
                        for (currentProcess = 0; currentProcess <= numberOfProcesses - 1; currentProcess++)
                        {
                            if (sortedPriorities[processIndex] == priorities[currentProcess] && processFound == false)
                            {
                                waitingTimes[processIndex] = waitingTimes[processIndex - 1] + burstTimes[tempPriority];
                                MessageBox.Show("Waiting time for P" + (currentProcess + 1) + " = " + waitingTimes[processIndex], "Waiting time", MessageBoxButtons.OK);
                                tempPriority = currentProcess;
                                priorities[currentProcess] = 0;
                                processFound = true;
                            }
                        }
                        processFound = false;
                    }
                }
                for (processIndex = 0; processIndex <= numberOfProcesses - 1; processIndex++)
                {
                    totalWaitingTime = totalWaitingTime + waitingTimes[processIndex];
                }
                MessageBox.Show("Average waiting time for " + numberOfProcesses + " processes" + " = " + (averageWaitingTime = totalWaitingTime / numberOfProcesses) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt16(userInput);
            int processIndex, completedProcessCount = 0;
            double totalTime = 0.0;
            double timeQuantum;
            double totalWaitTime = 0, totalTurnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTimes = new double[10];
            double[] burstTimes = new double[10];
            double[] remainingBurstTimes = new double[10];
            int remainingProcesses = numberOfProcesses;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (processIndex = 0; processIndex < numberOfProcesses; processIndex++)
                {
                    string arrivalTimeInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (processIndex + 1),
                                                               "",
                                                               -1, -1);

                    arrivalTimes[processIndex] = Convert.ToInt64(arrivalTimeInput);

                    string burstTimeInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (processIndex + 1),
                                                               "",
                                                               -1, -1);

                    burstTimes[processIndex] = Convert.ToInt64(burstTimeInput);

                    remainingBurstTimes[processIndex] = burstTimes[processIndex];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToInt64(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                for (totalTime = 0, processIndex = 0; remainingProcesses != 0;)
                {
                    if (remainingBurstTimes[processIndex] <= timeQuantum && remainingBurstTimes[processIndex] > 0)
                    {
                        totalTime = totalTime + remainingBurstTimes[processIndex];
                        remainingBurstTimes[processIndex] = 0;
                        completedProcessCount = 1;
                    }
                    else if (remainingBurstTimes[processIndex] > 0)
                    {
                        remainingBurstTimes[processIndex] = remainingBurstTimes[processIndex] - timeQuantum;
                        totalTime = totalTime + timeQuantum;
                    }
                    if (remainingBurstTimes[processIndex] == 0 && completedProcessCount == 1)
                    {
                        remainingProcesses--;
                        MessageBox.Show("Turnaround time for Process " + (processIndex + 1) + " : " + (totalTime - arrivalTimes[processIndex]), "Turnaround time for Process " + (processIndex + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (processIndex + 1) + " : " + (totalTime - arrivalTimes[processIndex] - burstTimes[processIndex]), "Wait time for Process " + (processIndex + 1), MessageBoxButtons.OK);
                        totalTurnaroundTime = (totalTurnaroundTime + totalTime - arrivalTimes[processIndex]);
                        totalWaitTime = (totalWaitTime + totalTime - arrivalTimes[processIndex] - burstTimes[processIndex]);
                        completedProcessCount = 0;
                    }
                    if (processIndex == numberOfProcesses - 1)
                    {
                        processIndex = 0;
                    }
                    else if (arrivalTimes[processIndex + 1] <= totalTime)
                    {
                        processIndex++;
                    }
                    else
                    {
                        processIndex = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(totalWaitTime * 1.0 / numberOfProcesses);
                averageTurnaroundTime = Convert.ToInt64(totalTurnaroundTime * 1.0 / numberOfProcesses);
                MessageBox.Show("Average wait time for " + numberOfProcesses + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + numberOfProcesses + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
            }
        }

        internal static void edfAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt32(userInput); 

            DialogResult result = MessageBox.Show("Earliest Deadline First (EDF) Scheduling\n(Preemptive)\n\nSimulate this algorithm?", "EDF", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes) return;

            int[] arrivalTimes = new int[numberOfProcesses];
            int[] burstTimes = new int[numberOfProcesses];
            int[] deadlines = new int[numberOfProcesses];
            int[] remainingBurstTimes = new int[numberOfProcesses];
            int[] completionTimes = new int[numberOfProcesses];
            int[] waitingTimes = new int[numberOfProcesses];
            int[] turnaroundTimes = new int[numberOfProcesses];
            bool[] isCompleted = new bool[numberOfProcesses];

            for (int i = 0; i < numberOfProcesses; i++)
            {
                string arrivalTimeInput = Interaction.InputBox($"Enter arrival time for P{i + 1}:", $"P{i + 1} Arrival Time", "0", -1, -1);
                arrivalTimes[i] = Convert.ToInt32(arrivalTimeInput);

                string burstTimeInput = Interaction.InputBox($"Enter burst time for P{i + 1}:", $"P{i + 1} Burst Time", "1", -1, -1);
                burstTimes[i] = Convert.ToInt32(burstTimeInput);

                string deadlineInput = Interaction.InputBox($"Enter deadline for P{i + 1}:", $"P{i + 1} Deadline", $"{arrivalTimes[i] + burstTimes[i]}", -1, -1);
                deadlines[i] = Convert.ToInt32(deadlineInput);

                remainingBurstTimes[i] = burstTimes[i];
                isCompleted[i] = false;
            }


            int currentTime = 0;
            int completedProcesses = 0;

            while (completedProcesses < numberOfProcesses)
            {
                int earliestDeadlineProcess = -1;
                int minDeadline = int.MaxValue;

                for (int i = 0; i < numberOfProcesses; i++)
                {
                    if (arrivalTimes[i] <= currentTime && !isCompleted[i])
                    {
                        if (deadlines[i] < minDeadline)
                        {
                            minDeadline = deadlines[i];
                            earliestDeadlineProcess = i;
                        }
                        else if (deadlines[i] == minDeadline)
                        {
                            if (earliestDeadlineProcess == -1 || arrivalTimes[i] < arrivalTimes[earliestDeadlineProcess])
                            {
                                earliestDeadlineProcess = i;
                            }
                        }
                    }
                }

                if (earliestDeadlineProcess != -1)
                {
                    remainingBurstTimes[earliestDeadlineProcess]--;
                    currentTime++;

                    if (remainingBurstTimes[earliestDeadlineProcess] == 0)
                    {
                        completionTimes[earliestDeadlineProcess] = currentTime;
                        turnaroundTimes[earliestDeadlineProcess] = completionTimes[earliestDeadlineProcess] - arrivalTimes[earliestDeadlineProcess];
                        waitingTimes[earliestDeadlineProcess] = turnaroundTimes[earliestDeadlineProcess] - burstTimes[earliestDeadlineProcess];
                        isCompleted[earliestDeadlineProcess] = true;
                        completedProcesses++;

                        string deadlineStatus = (completionTimes[earliestDeadlineProcess] <= deadlines[earliestDeadlineProcess]) ? "Met" : "MISSED";
                        MessageBox.Show($"Process P{earliestDeadlineProcess + 1} finished at time {currentTime}\n" +
                                        $"Wait: {waitingTimes[earliestDeadlineProcess]}, Turnaround: {turnaroundTimes[earliestDeadlineProcess]}\n" +
                                        $"Deadline: {deadlines[earliestDeadlineProcess]} ({deadlineStatus})",
                                        "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    int nextArrivalTime = int.MaxValue;
                    bool foundFutureArrival = false;
                    for (int i = 0; i < numberOfProcesses; i++)
                    {
                        if (!isCompleted[i] && arrivalTimes[i] > currentTime)
                        {
                            nextArrivalTime = Math.Min(nextArrivalTime, arrivalTimes[i]);
                            foundFutureArrival = true;
                        }
                    }

                    if (foundFutureArrival)
                    {
                        currentTime = nextArrivalTime;
                    }
                    else
                    {
                        currentTime++;
                    }
                }
            }

            double totalWaitTime = 0;
            double totalTurnaroundTime = 0;
            int deadlinesMissed = 0;
            System.Text.StringBuilder resultSummary = new System.Text.StringBuilder("EDF Simulation Results:\n");

            for (int i = 0; i < numberOfProcesses; i++)
            {
                totalWaitTime += waitingTimes[i];
                totalTurnaroundTime += turnaroundTimes[i];
                string deadlineStatus = "Met";
                // Need completionTimes even without validation to check deadline
                if (isCompleted[i] && completionTimes[i] > deadlines[i])
                {
                    deadlineStatus = $"MISSED (Completed: {completionTimes[i]})";
                    deadlinesMissed++;
                }
                // Display results even if completion time wasn't properly calculated due to bad input previously
                resultSummary.AppendLine($"P{i + 1}: Arrival Time={arrivalTimes[i]}, Burst Time={burstTimes[i]}, Deadline={deadlines[i]}\n Wait Time={waitingTimes[i]}, Turn-around Time ={turnaroundTimes[i]}, Completion Time={completionTimes[i]}, Deadline Status: {deadlineStatus}");
            }

            double averageWaitTime = (numberOfProcesses > 0) ? (totalWaitTime / (double)numberOfProcesses) : 0;
            double averageTurnaroundTime = (numberOfProcesses > 0) ? (totalTurnaroundTime / (double)numberOfProcesses) : 0;

            resultSummary.AppendLine($"\nAverage Waiting Time: {averageWaitTime:F2} sec(s)");
            resultSummary.AppendLine($"Average Turnaround Time: {averageTurnaroundTime:F2} sec(s)");
            resultSummary.AppendLine($"Total Deadlines Missed: {deadlinesMissed}");

            MessageBox.Show(resultSummary.ToString(), "EDF Simulation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        internal static void srtfAlgorithm(string userInput)
        {
            int numberOfProcesses = Convert.ToInt32(userInput);

            DialogResult result = MessageBox.Show("Shortest Remaining Time First (SRTF) Scheduling\n(Preemptive)\n\nSimulate this algorithm?", "SRTF", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes) return;

            int[] arrivalTimes = new int[numberOfProcesses];
            int[] burstTimes = new int[numberOfProcesses];
            int[] remainingBurstTimes = new int[numberOfProcesses];
            int[] completionTimes = new int[numberOfProcesses];
            int[] waitingTimes = new int[numberOfProcesses];
            int[] turnaroundTimes = new int[numberOfProcesses];
            bool[] isCompleted = new bool[numberOfProcesses];

            for (int i = 0; i < numberOfProcesses; i++)
            {
                string arrivalTimeInput = Interaction.InputBox($"Enter arrival time for P{i + 1}:", $"P{i + 1} Arrival Time", "0", -1, -1);
                arrivalTimes[i] = Convert.ToInt32(arrivalTimeInput);

                string burstTimeInput = Interaction.InputBox($"Enter burst time for P{i + 1}:", $"P{i + 1} Burst Time", "1", -1, -1);
                burstTimes[i] = Convert.ToInt32(burstTimeInput);

                remainingBurstTimes[i] = burstTimes[i];
                isCompleted[i] = false;
            }

            int currentTime = 0;
            int completedProcesses = 0;

            while (completedProcesses < numberOfProcesses)
            {
                int shortestJobIndex = -1;
                int minRemainingTime = int.MaxValue;

                for (int i = 0; i < numberOfProcesses; i++)
                {
                    if (arrivalTimes[i] <= currentTime && !isCompleted[i])
                    {
                        if (remainingBurstTimes[i] < minRemainingTime)
                        {
                            minRemainingTime = remainingBurstTimes[i];
                            shortestJobIndex = i;
                        }
                        else if (remainingBurstTimes[i] == minRemainingTime)
                        {
                            if (shortestJobIndex == -1 || arrivalTimes[i] < arrivalTimes[shortestJobIndex])
                            {
                                shortestJobIndex = i;
                            }
                        }
                    }
                }

                if (shortestJobIndex != -1)
                {
                    remainingBurstTimes[shortestJobIndex]--;
                    currentTime++;

                    if (remainingBurstTimes[shortestJobIndex] == 0)
                    {
                        completionTimes[shortestJobIndex] = currentTime;
                        turnaroundTimes[shortestJobIndex] = completionTimes[shortestJobIndex] - arrivalTimes[shortestJobIndex];
                        waitingTimes[shortestJobIndex] = turnaroundTimes[shortestJobIndex] - burstTimes[shortestJobIndex];
                        isCompleted[shortestJobIndex] = true;
                        completedProcesses++;

                        MessageBox.Show($"Process P{shortestJobIndex + 1} finished at time {currentTime}\n" +
                                        $"Wait: {waitingTimes[shortestJobIndex]}, Turnaround: {turnaroundTimes[shortestJobIndex]}",
                                        "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    int nextArrivalTime = int.MaxValue;
                    bool foundFutureArrival = false;
                    for (int i = 0; i < numberOfProcesses; i++)
                    {
                        if (!isCompleted[i] && arrivalTimes[i] > currentTime)
                        {
                            nextArrivalTime = Math.Min(nextArrivalTime, arrivalTimes[i]);
                            foundFutureArrival = true;
                        }
                    }

                    if (foundFutureArrival)
                    {
                        currentTime = nextArrivalTime;
                    }
                    else
                    {
                        currentTime++;
                    }
                }
            }

            double totalWaitTime = 0;
            double totalTurnaroundTime = 0;
            System.Text.StringBuilder resultSummary = new System.Text.StringBuilder("SRTF Simulation Results\n");

            for (int i = 0; i < numberOfProcesses; i++)
            {
                totalWaitTime += waitingTimes[i];
                totalTurnaroundTime += turnaroundTimes[i];
                resultSummary.AppendLine($"P{i + 1}: Arrival Time={arrivalTimes[i]}, Burst Tieme={burstTimes[i]}\n Waiting Time ={waitingTimes[i]}, Turn-Around Time ={turnaroundTimes[i]}, Completion Time={completionTimes[i]}");
            }

            double averageWaitTime = (numberOfProcesses > 0) ? (totalWaitTime / (double)numberOfProcesses) : 0;
            double averageTurnaroundTime = (numberOfProcesses > 0) ? (totalTurnaroundTime / (double)numberOfProcesses) : 0;

            resultSummary.AppendLine($"\nAverage Waiting Time: {averageWaitTime:F2} sec(s)");
            resultSummary.AppendLine($"Average Turnaround Time: {averageTurnaroundTime:F2} sec(s)");

            MessageBox.Show(resultSummary.ToString(), "SRTF simulation complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
