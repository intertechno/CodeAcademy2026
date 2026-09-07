# Text classification demo: Spam vs. Ham

from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB

# 1. Training data
texts = [
    # Original examples
    "Win money now",
    "Lowest price guaranteed",
    "Meet me at 5pm",
    "How about lunch tomorrow?",
    "Claim your free prize",
    "Let's catch up this weekend",

    # Additional spam examples
    "You have won a cash prize",
    "Get rich quick today",
    "Exclusive offer just for you",
    "Congratulations! You are a winner",
    "Free gift waiting for you",
    "Act now and save 90%",
    "Limited time offer",
    "Earn money from home",
    "Click here to claim your reward",
    "You have been selected",
    "Get your free coupon",
    "Huge discount available now",
    "Buy one get one free",
    "Special deal expires today",
    "Congratulations on your free vacation",
    "Claim your bonus now",
    "Unlock your exclusive reward",
    "You won a shopping voucher",
    "Free trial available today",
    "Make extra cash easily",
    "Don't miss this amazing deal",
    "Last chance to claim your prize",
    "Save big on our special offer",
    "Receive your free gift today",
    "Exclusive discount for members",

    # Additional ham examples
    "Are we still meeting tomorrow?",
    "Can you send me the report?",
    "The meeting starts at 10am",
    "I'll call you after work",
    "Please review the attached document",
    "What time should we leave?",
    "Thanks for your help yesterday",
    "Can we reschedule our meeting?",
    "Dinner is ready",
    "See you at the office tomorrow",
    "Could you bring some coffee?",
    "The project deadline is Friday",
    "Let's discuss this after lunch",
    "Are you free this evening?",
    "I'll send the files later",
    "Don't forget your appointment",
    "Happy birthday!",
    "Can you pick me up at six?",
    "The train arrives at 8pm",
    "Let's meet for coffee",
    "I finished the report",
    "Thanks for sending the information",
    "Are you coming to the party?",
    "Please call me when you arrive",
    "See you next week"
]

labels = [
    # Original labels
    "spam", "spam", "ham", "ham", "spam", "ham",

    # Labels for additional spam examples
    "spam", "spam", "spam", "spam", "spam",
    "spam", "spam", "spam", "spam", "spam",
    "spam", "spam", "spam", "spam", "spam",
    "spam", "spam", "spam", "spam", "spam",
    "spam", "spam", "spam", "spam", "spam",

    # Labels for additional ham examples
    "ham", "ham", "ham", "ham", "ham",
    "ham", "ham", "ham", "ham", "ham",
    "ham", "ham", "ham", "ham", "ham",
    "ham", "ham", "ham", "ham", "ham",
    "ham", "ham", "ham", "ham", "ham"
]

# 2. Convert text → bag-of-words
vectorizer = CountVectorizer()
X = vectorizer.fit_transform(texts)

# 3. Train a classifier
clf = MultinomialNB()
clf.fit(X, labels)

# 4. Try new examples
new_texts = ["free money for you", "are we still meeting today?", "exclusive offer just for you", "let's have lunch tomorrow"]
X_new = vectorizer.transform(new_texts)
predictions = clf.predict(X_new)

for text, label in zip(new_texts, predictions):
    print(f"{text!r} → {label}")
