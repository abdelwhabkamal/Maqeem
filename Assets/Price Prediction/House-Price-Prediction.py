import numpy as np
import xgboost as xgb
import pandas as pd
from sklearn.model_selection import train_test_split

class HousePricePrediction:
    def __init__(self):
      property_df=pd.read_csv('/content/sample_data/data.csv', index_col=[0])
      features = property_df.drop(columns = ['price','city','furnished'])
      target = property_df[['price']]
      X_train, X_valid, Y_train, Y_valid = train_test_split(features, target, test_size=0.2, random_state=1000)
      self.model = xgb.XGBRegressor(
        learning_rate=0.1,
		    max_depth=12,
		    n_estimators=1000
	    )
      self.model.fit(X_train, Y_train)
      y_train_pred = self.model.predict(X_valid) 

    def predict(self, features):
      input_features = np.array(features).reshape(1, -1)
      predicted_price = self.model.predict(input_features)[0]
      return predicted_price