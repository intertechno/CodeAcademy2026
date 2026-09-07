# Text classification demo: Spam vs. Ham

from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB

# 1. Training data
texts = [
    "Win money now", 
    "Lowest price guaranteed", 
    "Meet me at 5pm", 
    "How about lunch tomorrow?",
    "Claim your free prize",
    "Let's catch up this weekend"
]
labels = ["spam", "spam", "ham", "ham", "spam", "ham"]  # ground truth

# 2. Convert text → bag-of-words
vectorizer = CountVectorizer()
X = vectorizer.fit_transform(texts)

# 3. Train a classifier
clf = MultinomialNB()
clf.fit(X, labels)

# 4. Try new examples
new_texts = ["free money for you", "are we still meeting today?"]
X_new = vectorizer.transform(new_texts)
predictions = clf.predict(X_new)

for text, label in zip(new_texts, predictions):
    print(f"{text!r} → {label}")
