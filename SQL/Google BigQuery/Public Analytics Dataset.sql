Task 2. What is the most active day of the week 6.3.2017 based on page views?
--
SELECT date,
SUM(totals.pageviews) AS pageviews
FROM `bigquery-public-data.google_analytics_sample.ga_sessions_201703*`
WHERE _TABLE_SUFFIX BETWEEN '06' AND '12'
GROUP BY date
ORDER BY date
--


Task 3. What are the PageViews figures for October 5, 12, and 19, 2016?
--
WITH ga_tables AS (
	SELECT date,
	SUM(totals.pageviews) AS pageviews,
	FROM `bigquery-public-data.google_analytics_sample.ga_sessions_20161005`
	GROUP BY date
	UNION ALL
	SELECT date,
	SUM(totals.pageviews) AS pageviews,
	FROM `bigquery-public-data.google_analytics_sample.ga_sessions_20161012`
	GROUP BY date
	UNION ALL
	SELECT date,
	SUM(totals.pageviews) AS pageviews,
	FROM `bigquery-public-data.google_analytics_sample.ga_sessions_20161019`
	GROUP BY date
)
SELECT
date,
pageviews
FROM ga_tables
ORDER BY date ASC
--


4. What is the most common page loaded (PageTitle field) as of August 1, 2016?
--
SELECT h.page.pageTitle, COUNT(*) AS HitCount
FROM
  `bigquery-public-data.google_analytics_sample.ga_sessions_20161005`,
  UNNEST(hits) AS h
GROUP BY h.page.pageTitle
ORDER BY HitCount DESC
--
