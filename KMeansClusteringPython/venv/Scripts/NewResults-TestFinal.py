from __future__ import absolute_import
from __future__ import division
from __future__ import print_function
from io import StringIO
from sklearn.cluster import KMeans
from sklearn.metrics.pairwise import euclidean_distances
from sklearn.metrics import silhouette_score

import numpy as np
import fileinput
import pandas as pd
import sys
import time
import openpyxl
from sklearn import metrics
from scipy.spatial.distance import cdist
import os.path
from pandas.io.formats.style import Styler
import jinja2
from openpyxl.utils import get_column_letter
import pprint
import csv
from scipy.cluster.vq import kmeans2
import io
from matplotlib import pyplot as plt

# pd.set_option('display.max_columns', None)
# pd.set_option('max_colwidth', -1)
# pd.set_option('display.large_repr', 'truncate')
# pd.set_option('display.max_column',None)
# pd.set_option('display.max_seq_items',None)
# pd.set_option('display.max_colwidth', 500)

EBScor =([['0','0','0','0','0']])
SilScor =([['0','0','0','0','0']])
ServCal =([['0','0','0','0','0','0','0','0','0']])
nodedata = ([['0','0']])
ServCal.clear()
nodedata.clear()

currentservice = 'l'
currentnodetype = '1'
currentsize = 'l'
currentIteration ='1'

service = '1'
NodeSize = 0
NodeType ='1'
Cost = 0
Capacity = 0
Iteration = 0
totalnodeCostsum = 0
totalnodeCapacitysum = 0


# #Formatting in Dataframe
pd.set_option('display.expand_frame_repr', False)
pd.set_option('display.max_rows',None)
# pd.set_option('display.float_format', '{:.8f}'.format)

# Importing the dataset

f = pd.read_csv('C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/PythonFile.csv')

# Working with Existing Data
RrtPurCost = f['Cost']
RrtInsCost = f['Cost'] * 0.2

f['TotRtrCost'] = RrtPurCost + RrtInsCost
f['UnitCost'] = f['TotRtrCost'] / f['Capacity']
# print(df)
f = f.drop(['Cost', 'UnitCost'], axis=1)
SumDivold= f.groupby(['Service','Node','Iteration'], as_index=False).sum().eval('NetworkServiceUnitCostM1 = TotRtrCost / Capacity')
# print(SumDivold,'\n')
# #FINAL OUTPUT
SumDivData = SumDivold.drop(['Iteration'], axis=1)
SumDivData= SumDivData.groupby(['Service','Node' ], as_index=False).mean()
# print(SumDivData)
# SAVE OUTPUT IN EXCEL
# SumDivData.to_excel('TestIterationfileM1.xlsx', sheet_name='CostGap', index=False)

# For ML Algo Starts Here


Lines = iter(fileinput.input(['C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/PythonFile.csv']))
next(Lines)
i = 0
for f in Lines:
        Ln = (f)
        #print(Ln)
        my_list = Ln.split(',')
        # print(my_list)
        i = i+  1
        # print(Lines)
        # print(my_list)
        if len(my_list) == 6 and i==1:
            currentservice= my_list[0]
            currentsize = my_list[1]
            currentIteration = my_list[2]
            currentnodetype = my_list[3]



        # print(my_list)
        # print(len(my_list))
        service = my_list[0]
        # print(my_list[0])
        NodeSize = my_list[1]
        # print(my_list[1])
        Iteration = int(my_list[2])
        NodeType = my_list[3]
        # print(my_list[3])
        Cost = my_list[4]
        # print(Cost)
        Capacity = my_list[5]

        #check why this is here
        lastservice = service
        lastsize = NodeSize
        lastIteration = Iteration
        lastnode = NodeType




        if service == currentservice and NodeSize == currentsize and Iteration == currentIteration :
            servicechanged = 0
            sizechanged = 0
            Iterationchanged = 0

        else:
            # current service is set from the last loop after calculation
            lastservice = currentservice
            lastsize = currentsize
            lastIteration = currentIteration

            servicechanged=1
            sizechanged = 1
            Iterationchanged = 1

        if currentnodetype == NodeType:
            nodechanged = 0
            sizechanged = 0

        else:
            nodechanged=1
            # sizechanged = 0

            # print("node changed")

        if nodechanged==0 :
            lastnode = NodeType
            lastsize = NodeSize



            nodedata.append([int(Cost), int(Capacity)])
            totalnodeCostsum = totalnodeCostsum + int(Cost)
            totalnodeCapacitysum = totalnodeCapacitysum + int(Capacity)

            #NODE LEVEL
                # put that in array to send

        if nodechanged==1:

                lastnode = currentnodetype
                lastsize = currentsize

                # print(nodedata)
                #Begin AI
                #nodedata.to_numpy()
                # Initializing KMeans
                #  print(currentnodetype)
                # print(currentservice)

              #SILHOUTTE METHOD -CLUSTER Evaluation (working)
                # range_n_clusters = list(range(2, 4))
                # #print("Number of clusters from 2 to 9: \n", range_n_clusters)
                #
                # for n_clusters in range_n_clusters:
                #     clusterer = KMeans(n_clusters=n_clusters).fit(nodedata)
                #
                #     centers = clusterer.cluster_centers_
                #     labels = clusterer.labels_
                #
                #     SilScore = silhouette_score(nodedata, labels, metric = 'euclidean')
                #     #print("For n_clusters = {}, silhouette score is {})".format(n_clusters, SilScore))
                #     #print("Score for 3 Cluster for ", lastsize, lastnode, "node in", lastservice, "service for", lastIteration, "is",SilScore,'\n')
                #     SilScor.append([lastservice, lastsize, lastIteration, lastnode, SilScore])



                    # ELBOW METHOD -CLUSTER Evaluation(working)
                # WSSE = []
                # K = range(2, 5)
                # for k in K:
                #     kmeans = KMeans(n_clusters=k).fit(nodedata)
                #     WSSE.append(kmeans.inertia_)
                #
                # # Plot the elbow
                # plt.plot(K, WSSE, 'bx-')
                # plt.xlabel('k')
                # plt.ylabel('SSE')
                # plt.title('The Elbow Method showing the optimal k')
                #plt.show()
                          # ALGO START

                kmeans = KMeans(n_clusters=2, init='k-means++', max_iter=50,algorithm='auto')
                # #Fitting with inputs
                kmeans = kmeans.fit(nodedata)
                # Getting the cluster centers
                Centroids = kmeans.cluster_centers_
                # # # Predicting the clusters
                labels = kmeans.labels_
                # print(lastservice)
                #
                # #now final center or mean in T1 T2 T3 for cost and capacity
                # print(Centroids)
                # print(labels)
                # print(len(labels))

                #working
                #SSE =kmeans.inertia_
                #EBScor.append([lastservice, lastsize, lastIteration, lastnode, SSE])

                #dists = euclidean_distances(kmeans.cluster_centers_)
                #SilScore= silhouette_score(nodedata, kmeans.labels_)
                #SilScor.append([lastservice, lastsize, lastIteration, lastnode, SilScore])
                # print("Score for 3 Cluster for ", lastsize, lastnode, "node in", lastservice, "service for", lastIteration, "is",SilScore,'\n')


                # print(kmeans.score(nodedata))

                # print(Dist)
                #print(dists)
#                 tri_dists = dists[np.triu_indices(3, 1)]
#                 max_dist, avg_dist, min_dist = tri_dists.max(), tri_dists.mean(), tri_dists.min()
#                 print(tri_dists, max_dist, avg_dist, min_dist )
#
#                 #PLOTTING CENTROIDS AND DATA POINTS IN GROUP
#                 centers = np.array(kmeans.cluster_centers_)
#                 Data = np.array(nodedata)
#                 plt.figure('3 Cluster K-Means')
#
#                 plt.scatter(Data[:, 0], Data[:, 1], c=kmeans.labels_,label = lastservice)
#                 plt.legend(loc=0, bbox_to_anchor=(0.17,1.1))
#                 plt.annotate(lastnode, xy=(95, 283), xycoords='axes points',
#                              size=11, ha='right', va='top', color='navy')
#
#                 n = ['T1','T2','T3']
#                 plt.scatter(centers[:, 0], centers[:, 1], marker="x", color='r')
#                 for i, txt in enumerate(n):
#                     plt.annotate(txt, (centers[:, 0][i], centers[:, 1][i]))
#
#
#                 plt.xlabel('Cost')
#                 plt.ylabel('Capacity')
#                 plt.title('3 Cluster K-Means')
#                 plt.grid()
# #                 # plt.show()
# #
#                 plt.show(block=False)
#                 plt.pause(2)
#                 plt.close()


                flag = 0
                nodevalueat0 = [0,0]
                nodevalueat1 = [0,0]
                # nodevalueat2 = [0,0]
                # nodevalueat3 = [0,0]
                # nodevalueat4 = [0,0]
                # nodevalueat5 = [0, 0]
                # nodevalueat6 = [0, 0]
                nodevalueat0.clear()
                nodevalueat1.clear()
                # nodevalueat2.clear()
                # nodevalueat3.clear()
                # nodevalueat4.clear()
                # nodevalueat5.clear()
                # nodevalueat6.clear()
                for x in labels[:]:

                    #print(x)
                    if x ==0:
                        # the final assignment of values in T1 T2 and T3 then algo would take final mean for h group
                        nodevalueat0.append(nodedata[flag])
                    if x==1:
                        nodevalueat1.append(nodedata[flag])
                    # if x ==2:
                    #    nodevalueat2.append(nodedata[flag])
                    # if x == 3:
                    #    nodevalueat3.append(nodedata[flag])
                    # if x == 4:
                    #    nodevalueat4.append(nodedata[flag])
                    # if x == 5:
                    #    nodevalueat5.append(nodedata[flag])
                    # if x == 6:
                    #    nodevalueat6.append(nodedata[flag])
                    flag = flag +1
                # print(lastnode)
                # print(service)
#



#                     #a = np.array(nodevalueat0)
                nodevalavg0 = np.median(np.array(nodevalueat0), axis=0)
                #print(nodevalavg0)
                nodevalavg1 = np.median(np.array(nodevalueat1), axis=0)
                #print(nodevalavg1)
                # nodevalavg2 = np.median(np.array(nodevalueat2), axis=0)
                # #print(nodevalavg2)
                # nodevalavg3 = np.median(np.array(nodevalueat3), axis=0)
                # nodevalavg4 = np.median(np.array(nodevalueat4), axis=0)
                # # nodevalavg5 = np.median(np.array(nodevalueat5), axis=0)
                # nodevalavg6 = np.median(np.array(nodevalueat6), axis=0)
# # #


                # T1 Data
                T1Count = len(nodevalueat0)

                T1Cost = nodevalavg0[0]
                T1Cap = nodevalavg0[1]
                T1RtrCost = ((T1Cost * 0.2) + T1Cost) * T1Count
                T1RtrCap = T1Cap * T1Count
                #print(lastservice, lastsize, lastIteration, lastnode, T1Count, T1Cost, T1RtrCost, T1Cap, T1RtrCap)
                ServCal.append([lastservice, lastsize, lastIteration, lastnode, T1Count, T1Cost, T1RtrCost, T1Cap, T1RtrCap])

                # T2 Data
                T2Count = len(nodevalueat1)

                T2Cost = nodevalavg1[0]
                T2Cap = nodevalavg1[1]
                T2RtrCost = ((T2Cost * 0.2) + T2Cost) * T2Count
                T2RtrCap = T2Cap * T2Count
                #print(lastservice, lastsize,lastIteration, lastnode, T2Count, T2Cost, T2RtrCost, T2Cap, T2RtrCap)
                ServCal.append([lastservice, lastsize, lastIteration, lastnode, T2Count, T2Cost, T2RtrCost, T2Cap, T2RtrCap])
                ##T3 Data
               #  T3Count = len(nodevalueat2)
               #
               #  T3Cost = nodevalavg2[0]
               #  T3Cap = nodevalavg2[1]
               #  T3RtrCost = ((T3Cost * 0.2) + T3Cost) * T3Count
               #  T3RtrCap = T3Cap * T3Count
               #  #print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
               #  ServCal.append([lastservice, lastsize, lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap])
               #
               # # T4 Data
               #  T4Count = len(nodevalueat3)
               #  T4Cost = nodevalavg3[0]
               #  T4Cap = nodevalavg3[1]
               #  T4RtrCost = ((T4Cost * 0.2) + T4Cost) * T4Count
               #  T4RtrCap = T4Cap * T4Count
               #  #print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
               #  ServCal.append(
               #      [lastservice, lastsize, lastIteration, lastnode, T4Count, T4Cost, T4RtrCost, T4Cap, T4RtrCap])
               #
               #  # T5 Data
               #  T5Count = len(nodevalueat4)
               #  T5Cost = nodevalavg4[0]
               #  T5Cap = nodevalavg4[1]
               #  T5RtrCost = ((T5Cost * 0.2) + T5Cost) * T5Count
               #  T5RtrCap = T5Cap * T5Count
               #  # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
               #  ServCal.append(
               #      [lastservice, lastsize, lastIteration, lastnode, T5Count, T5Cost, T5RtrCost, T5Cap, T5RtrCap])
                # #
                # # # T6 Data
                # T6Count = len(nodevalueat5)
                # T6Cost = nodevalavg5[0]
                # T6Cap = nodevalavg5[1]
                # T6RtrCost = ((T6Cost * 0.2) + T6Cost) * T6Count
                # T6RtrCap = T6Cap * T6Count
                # # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
                # ServCal.append(
                #     [lastservice, lastsize, lastIteration, lastnode, T6Count, T6Cost, T6RtrCost, T6Cap, T6RtrCap])
                #
                # # T7 Data
                # T7Count = len(nodevalueat6)
                # T7Cost = nodevalavg6[0]
                # T7Cap = nodevalavg6[1]
                # T7RtrCost = ((T7Cost * 0.2) + T7Cost) * T7Count
                # T7RtrCap = T7Cap * T7Count
                # # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
                # ServCal.append(
                #     [lastservice, lastsize, lastIteration, lastnode, T7Count, T7Cost, T7RtrCost, T7Cap, T7RtrCap])

                #hold for service

                #End AI
                currentnodetype = NodeType
                lastnode = NodeType
                currentsize = NodeSize
                lastsize = NodeSize
                # currentIteration = Iteration
                # lastIteration=Iteration
                totalnodeCostsum = 0
                totalnodeCapacitysum = 0
                nodedata.clear()

                nodedata.append([int(Cost), int(Capacity)])
                # totalnodeCostsum = sum(map(float, Cost))
                # totalnodeCapacitysum = int(Capacity)

                # calculate Service  sum

                # SumCost = T1Cost + T2Cost + T3Cost
                # print( SumCost)


        if servicechanged==1 :


                nodechanged=2
                currentservice = service
                currentsize = NodeSize
                currentIteration =Iteration
                currentnodetype = NodeType
                # print(nodedata)
                nodedata.clear()

                nodedata.append([int(Cost), int(Capacity)])
                totalnodeCostsum = int(Cost)
                totalnodeCapacitysum = int(Capacity)
                # print('\n')


# from sklearn.cluster import MiniBatchKMeans
#
# mbk = MiniBatchKMeans(init='k-means++', n_clusters=3, batch_size=6,
#                       n_init=10, max_no_improvement=10, verbose=0)
#
# mbk.fit(nodedata)
#
# Centroids = mbk.cluster_centers_
# labels = mbk.labels_

#END OF FILE FOR LAST NODE



# Initializing KMeans
kmeans = KMeans(n_clusters=2,init='k-means++', max_iter=50,  algorithm='auto',n_init=1)
# #Fitting with inputs
kmeans = kmeans.fit(nodedata)
# # Getting the cluster centers
Centroids = kmeans.cluster_centers_
# # # Predicting the clusters
labels = kmeans.labels_
# print(lastservice)
#
# print(Centroids)
# print(labels)
#print(len(labels))

#Sum of Squares (working)
#SSE= kmeans.inertia_
#EBScor.append([lastservice, lastsize, lastIteration, lastnode, SSE])

# dists = euclidean_distances(kmeans.cluster_centers_)
#SilScore= silhouette_score(nodedata, kmeans.labels_)
#SilScor.append([lastservice, lastsize, lastIteration, lastnode, SilScore])
#print("Score for 3 Cluster for ", lastsize, lastnode, "node in", lastservice, "service for", lastIteration, "is",SilScore,'\n')
#print (kmeans.score(nodedata))

# print(Dist)
# print(dists)
# tri_dists = dists[np.triu_indices(3, 1)]
# max_dist, avg_dist, min_dist = tri_dists.max(), tri_dists.mean(), tri_dists.min()
# print(tri_dists, max_dist, avg_dist, min_dist)


flag = 0
nodevalueat0 = [0, 0]
nodevalueat1 = [0, 0]
# nodevalueat2 = [0, 0]
# nodevalueat3= [0, 0]
# nodevalueat4= [0, 0]
# nodevalueat5= [0, 0]
# nodevalueat6= [0, 0]
nodevalueat0.clear()
nodevalueat1.clear()
# nodevalueat2.clear()
# nodevalueat3.clear()
# nodevalueat4.clear()
# # nodevalueat5.clear()
# nodevalueat6.clear()
for x in labels[:]:

    # print(x)
    if x == 0:
        nodevalueat0.append(nodedata[flag])
    if x == 1:
        nodevalueat1.append(nodedata[flag])
    # if x == 2:
    #     nodevalueat2.append(nodedata[flag])
    # if x == 3:
    #     nodevalueat3.append(nodedata[flag])
    # if x == 4:
    #     nodevalueat4.append(nodedata[flag])
    # if x == 5:
    #     nodevalueat5.append(nodedata[flag])
    # if x == 6:
    #     nodevalueat6.append(nodedata[flag])
    flag = flag + 1
# print(lastnode)
# print(service)

# a = np.array(nodevalueat0)
nodevalavg0 = np.median(np.array(nodevalueat0), axis=0)
# print(nodevalavg0)
nodevalavg1 = np.median(np.array(nodevalueat1), axis=0)
# print(nodevalavg1)
# nodevalavg2 = np.median(np.array(nodevalueat2), axis=0)
# # #print(nodevalavg2)
# nodevalavg3 = np.median(np.array(nodevalueat3), axis=0)
# nodevalavg4 = np.median(np.array(nodevalueat4), axis=0)
# nodevalavg5 = np.median(np.array(nodevalueat5), axis=0)
# nodevalavg6 = np.median(np.array(nodevalueat6), axis=0)
# T1 Data
T1Count = len(nodevalueat0)
T1Cost = nodevalavg0[0]
T1Cap = nodevalavg0[1]
T1RtrCost = ((T1Cost * 0.2) + T1Cost) * T1Count
T1RtrCap = T1Cap * T1Count
#print(lastservice, lastsize,lastIteration, lastnode, T1Count, T1Cost, T1RtrCost, T1Cap, T1RtrCap)
ServCal.append([lastservice, lastsize, lastIteration, lastnode, T1Count, T1Cost, T1RtrCost, T1Cap, T1RtrCap])

# T2 Data
T2Count = len(nodevalueat1)

T2Cost = nodevalavg1[0]
T2Cap = nodevalavg1[1]
T2RtrCost = ((T2Cost * 0.2) + T2Cost) * T2Count
T2RtrCap = T2Cap * T2Count
#print(lastservice, lastsize,lastIteration, lastnode, T2Count, T2Cost, T2RtrCost, T2Cap, T2RtrCap)
ServCal.append([lastservice, lastsize, lastIteration, lastnode, T2Count, T2Cost, T2RtrCost, T2Cap, T2RtrCap])
# # T3 Data
# T3Count = len(nodevalueat2)
#
# T3Cost = nodevalavg2[0]
# T3Cap = nodevalavg2[1]
# T3RtrCost = ((T3Cost * 0.2) + T3Cost) * T3Count
# T3RtrCap = T3Cap * T3Count
# #print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
# ServCal.append([lastservice, lastsize, lastIteration, lastnode,T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap])
#
# # T4 Data
# T4Count = len(nodevalueat3)
# T4Cost = nodevalavg3[0]
# T4Cap = nodevalavg3[1]
# T4RtrCost = ((T4Cost * 0.2) + T4Cost) * T4Count
# T4RtrCap = T4Cap * T4Count
# #print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
# ServCal.append([lastservice, lastsize, lastIteration, lastnode, T4Count, T4Cost, T4RtrCost, T4Cap, T4RtrCap])
#
# # T5 Data
# T5Count = len(nodevalueat4)
# T5Cost = nodevalavg4[0]
# T5Cap = nodevalavg4[1]
# T5RtrCost = ((T5Cost * 0.2) + T5Cost) * T5Count
# T5RtrCap = T5Cap * T5Count
# # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
# ServCal.append([lastservice, lastsize, lastIteration, lastnode, T5Count, T5Cost, T5RtrCost, T5Cap, T5RtrCap])
# #
# # T6 Data
# T6Count = len(nodevalueat5)
# T6Cost = nodevalavg5[0]
# T6Cap = nodevalavg5[1]
# T6RtrCost = ((T6Cost * 0.2) + T6Cost) * T6Count
# T6RtrCap = T6Cap * T6Count
# # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
# ServCal.append(
#     [lastservice, lastsize, lastIteration, lastnode, T6Count, T6Cost, T6RtrCost, T6Cap, T6RtrCap])
#
# # T7 Data
# T7Count = len(nodevalueat6)
# T7Cost = nodevalavg6[0]
# T7Cap = nodevalavg6[1]
# T7RtrCost = ((T7Cost * 0.2) + T7Cost) * T7Count
# T7RtrCap = T7Cap * T7Count
# # print(lastservice, lastsize,lastIteration, lastnode, T3Count, T3Cost, T3RtrCost, T3Cap, T3RtrCap)
# ServCal.append(
#     [lastservice, lastsize, lastIteration, lastnode, T7Count, T7Cost, T7RtrCost, T7Cap, T7RtrCap])

#PLOTTING CENTROIDS AND DATA POINTS IN GROUP

# centers = np.array(kmeans.cluster_centers_)
# Data = np.array(nodedata)
# plt.figure('3 Cluster K-Means')
#
# plt.scatter(Data[:, 0], Data[:, 1], c=kmeans.labels_,label = lastservice)
# plt.legend(loc=0, bbox_to_anchor=(0.17,1.1))
# plt.annotate(lastnode, xy=(95, 283), xycoords='axes points',
#                              size=11, ha='right', va='top', color='navy')
#
# n = ['T1','T2','T3']
# plt.scatter(centers[:, 0], centers[:, 1], marker="x", color='r')
# for i, txt in enumerate(n):
#    plt.annotate(txt, (centers[:, 0][i], centers[:, 1][i]))
#
# plt.xlabel('Cost')
# plt.ylabel('Capacity')
# plt.title('3 Cluster K-Means')
# plt.grid()
# # # plt.show()
# #
# plt.show(block=False)
# plt.pause(2)
# plt.close()

#EBSc = pd.DataFrame(EBScor, columns=['Service', 'NodeSize', 'Iteration', 'NodeType', 'Score'])
#SilSc = pd.DataFrame(SilScor, columns=['Service', 'NodeSize', 'Iteration', 'NodeType', 'Score'])

df = pd.DataFrame(ServCal,columns=['Service','NodeSize','Iteration','NodeType','NodeUsed', 'Cost', 'TotRtrCost', 'Cap', 'TotRtrCap'])
#print (df)

# #Group every Service for node size and Iteration
# #Calculate Serivce Unit Cost

SumDiv= df.groupby(['Service','NodeSize','Iteration'],as_index=False).sum().eval('NetworkServiceUnitCostM3 = TotRtrCost / TotRtrCap')
#print(SumDiv)
#
#
#COstGAP Calc
SumDiv = pd.concat([SumDiv, SumDivold['NetworkServiceUnitCostM1']], axis=1)
SumDiv = SumDiv.assign(CostGapM3=(SumDiv.NetworkServiceUnitCostM1 - SumDiv.NetworkServiceUnitCostM3) / SumDiv.NetworkServiceUnitCostM1)

#print(SumDiv)

#FINAL OUTPUT
SumDiv = SumDiv.drop(['Iteration','Cost', 'TotRtrCost','Cap','TotRtrCap'], axis=1)

SumDiv= SumDiv.groupby(['Service','NodeSize'], as_index=False).mean()

print(SumDiv)


from pandas import ExcelWriter
from pandas import ExcelFile

# SAVE OUTPUT IN EXCEL



SumDiv.to_excel(r'C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/SendtoCSharps.xlsx', sheet_name='CostGap',index = False,engine='xlsxwriter')

df.to_excel('C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/dataTestIterationfile.xlsx', sheet_name='CostGap', index=False)

#SilSc.to_excel('C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/SIL.xlsx',sheet_name='sheet', index=False)
# EBSc.to_excel('C:/Users/Yasmeen Ali/Documents/PyCharmFiles/KMeansClusteringPython/EB.xlsx',sheet_name='sheet', index=False)
sys.exit()