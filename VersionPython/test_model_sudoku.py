# -*- coding: utf-8 -*-
"""
Created on Tue Jan 21 15:31:02 2020

@author: thoma
"""
import keras
from keras.layers import Activation
from keras.layers import Conv2D, BatchNormalization, Dense, Flatten, Reshape
from keras.models import load_model
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split


def test_model(x_train, y_train, x_test, y_test, batch_size=64, ep=2):
    
    print("Je suis au test")
    
    model = load_model('sudoku.model')
    prediction = model.predict(x_test)
    
    #score = model.evaluate(x_test, y_test, verbose=0)
    
    print('Score:', prediction)
    
def get_data(file): 

    data = pd.read_csv(file)

    feat_raw = data['quizzes']
    label_raw = data['solutions']

    feat = []
    label = []

    for i in feat_raw:
    
        x = np.array([int(j) for j in i]).reshape((9,9,1))
        feat.append(x)
    
    feat = np.array(feat)
    feat = feat/9
    feat -= .5    
    
    for i in label_raw:
    
        x = np.array([int(j) for j in i]).reshape((81,1)) - 1
        label.append(x)   
    
    label = np.array(label)
    
    del(feat_raw)
    del(label_raw)    

    x_train, x_test, y_train, y_test = train_test_split(feat, label, test_size=0.2, random_state=42)
    
    test_model(x_train, y_train, x_test, y_test)
    
    return x_train, x_test, y_train, y_test
    
data = get_data("sudoku.csv")