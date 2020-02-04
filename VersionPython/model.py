import keras
from keras.layers import Activation
from keras.layers import Conv2D, BatchNormalization, Dense, Flatten, Reshape
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split



def train_model(x_train, y_train, x_test, y_test, batch_size=64, ep=2):

    model = keras.models.Sequential()

    model.add(Conv2D(64, kernel_size=(3,3), activation='relu', padding='same', input_shape=(9,9,1)))
    model.add(BatchNormalization())
    model.add(Conv2D(64, kernel_size=(3,3), activation='relu', padding='same'))
    model.add(BatchNormalization())
    model.add(Conv2D(128, kernel_size=(1,1), activation='relu', padding='same'))

    model.add(Flatten())
    model.add(Dense(81*9))
    model.add(Reshape((-1, 9)))
    model.add(Activation('softmax'))
    
    adam = keras.optimizers.adam(lr=.001)
    model.compile(loss='sparse_categorical_crossentropy', optimizer=adam)

    print(model.fit(x_train, y_train, batch_size=batch_size, epochs=ep))

    model.save('sudoku.model')
    
    
#    score = model.evaluate(x_test, y_test, verbose=0)
#    print('Test loss:', score[0])
#    print('Test accuracy:', score[1])
    
    

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
    
    train_model(x_train, y_train, x_test, y_test)
    
    return x_train, x_test, y_train, y_test




    
#data = get_data("sudoku.csv")
