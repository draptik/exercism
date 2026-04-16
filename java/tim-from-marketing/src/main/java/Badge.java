class Badge {
    public String print(Integer id, String name, String department) {
        String displayId = id == null ? "" : "[" + id + "] - ";
        String displayName = name;
        String displayDepartment = department == null ? "OWNER" : department.toUpperCase();
        return displayId + displayName + " - " + displayDepartment;
    }
}
