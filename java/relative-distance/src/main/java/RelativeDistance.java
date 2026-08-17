import java.util.*;

class RelativeDistance {

    private final Map<String, Set<String>> graph;

    RelativeDistance(Map<String, List<String>> familyTree) {
        this.graph = buildGraph(familyTree);
    }

    private static Map<String, Set<String>> buildGraph(Map<String, List<String>> familyTree) {
        Map<String, Set<String>> graph = new HashMap<>();
        if (familyTree == null) {
            return graph;
        }

        Map<String, List<String>> childToParents = new HashMap<>();

        for (Map.Entry<String, List<String>> entry : familyTree.entrySet()) {
            String parent = entry.getKey();
            List<String> children = entry.getValue();
            if (parent == null || children == null) {
                continue;
            }

            graph.computeIfAbsent(parent, _ -> new HashSet<>());
            addParentAndChildRelationships(graph, childToParents, parent, children);
            connectAllPairs(graph, children);
        }

        for (List<String> parents : childToParents.values()) {
            connectAllPairs(graph, parents);
        }

        return graph;
    }

    private static void addParentAndChildRelationships(
            Map<String, Set<String>> graph,
            Map<String, List<String>> childToParents,
            String parent,
            List<String> children) {
        for (String child : children) {
            if (child == null) {
                continue;
            }
            addEdge(graph, parent, child);
            childToParents.computeIfAbsent(child, k -> new ArrayList<>()).add(parent);
        }
    }

    private static void connectAllPairs(Map<String, Set<String>> graph, List<String> persons) {
        for (int i = 0; i < persons.size(); i++) {
            for (int j = i + 1; j < persons.size(); j++) {
                String p1 = persons.get(i);
                String p2 = persons.get(j);
                if (p1 != null && p2 != null) {
                    addEdge(graph, p1, p2);
                }
            }
        }
    }

    private static void addEdge(Map<String, Set<String>> graph, String u, String v) {
        graph.computeIfAbsent(u, k -> new HashSet<>()).add(v);
        graph.computeIfAbsent(v, k -> new HashSet<>()).add(u);
    }

    int degreeOfSeparation(String personA, String personB) {
        if (personA == null || personB == null) {
            return -1;
        }
        if (!graph.containsKey(personA) || !graph.containsKey(personB)) {
            return -1;
        }
        if (personA.equals(personB)) {
            return 0;
        }

        Queue<String> queue = new ArrayDeque<>();
        Map<String, Integer> dist = new HashMap<>();

        queue.add(personA);
        dist.put(personA, 0);

        while (!queue.isEmpty()) {
            String current = queue.poll();
            int d = dist.get(current);

            if (current.equals(personB)) {
                return d;
            }

            for (String neighbor : graph.getOrDefault(current, Collections.emptySet())) {
                if (!dist.containsKey(neighbor)) {
                    dist.put(neighbor, d + 1);
                    queue.add(neighbor);
                }
            }
        }

        return -1;
    }
}
