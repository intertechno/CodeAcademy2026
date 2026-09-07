# Import necessary libraries
import tensorflow as tf
from tensorflow.keras import layers, models
import numpy as np
import matplotlib.pyplot as plt

# Load the Fashion MNIST dataset
(fashion_train_images, fashion_train_labels), (fashion_test_images, fashion_test_labels) = tf.keras.datasets.fashion_mnist.load_data()

# Normalize the pixel values of the images to be between 0 and 1
fashion_train_images, fashion_test_images = fashion_train_images / 255.0, fashion_test_images / 255.0

# Reshape the images to add a channel dimension (needed for CNN input)
fashion_train_images = fashion_train_images[..., np.newaxis]
fashion_test_images = fashion_test_images[..., np.newaxis]

# Split the training data into training and validation sets
from sklearn.model_selection import train_test_split
fashion_train_images, fashion_val_images, fashion_train_labels, fashion_val_labels = train_test_split(
    fashion_train_images, fashion_train_labels, test_size=0.2, random_state=42
)

# Define the model
model = models.Sequential([
    layers.Conv2D(32, (3, 3), activation='relu', input_shape=(28, 28, 1)),
    layers.MaxPooling2D((2, 2)),
    layers.Conv2D(64, (3, 3), activation='relu'),
    layers.MaxPooling2D((2, 2)),
    layers.Conv2D(64, (3, 3), activation='relu'),
    layers.Flatten(),
    layers.Dense(64, activation='relu'),
    layers.Dense(10, activation='softmax')
])

# Compile the model
model.compile(optimizer='adam',
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])

# Model summary
model.summary()

# Train the model
history = model.fit(fashion_train_images, fashion_train_labels, epochs=10,
                    validation_data=(fashion_val_images, fashion_val_labels))

# Evaluate the model on the test dataset
test_loss, test_acc = model.evaluate(fashion_test_images, fashion_test_labels, verbose=2)
print('\nTest accuracy:', test_acc)

# Plot training and validation accuracy over epochs
plt.plot(history.history['accuracy'], label='Training accuracy')
plt.plot(history.history['val_accuracy'], label='Validation accuracy')
plt.title('Training and validation accuracy')
plt.xlabel('Epoch')
plt.ylabel('Accuracy')
plt.legend()
plt.show()
