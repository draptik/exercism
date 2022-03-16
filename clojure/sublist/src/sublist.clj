(ns sublist)

(defn classify [list1 list2] ;; <- arglist goes here
      ;; your code goes here

  (defn sublist? [coll1 coll2]
    (some #{coll1} (partition (count coll1) 1 coll2)))

  ;; `defn-` defines a private function
  (defn- isEmpty [list]
    (= list []))

  (cond
    (= list1 list2) :equal
    (sublist? list1 list2) :sublist
    (sublist? list2 list1) :superlist
    :else :unequal))
  ;(if
  ;  (and
  ;    (isEmpty list1)
  ;    (isEmpty list2))
  ;  :equal
  ;  :sublist))
