<template>
  <div>
    <ul v-if="items.length">
      <ActivityItem 
        v-for="item in items" 
        :key="item.id"
        :item="item" 
          />
    </ul>
    <p v-else>
      No statuses.
    </p>
  </div>
</template>

<script>
  import ActivityItem from "./ActivityItem.vue";

  export default {
    components: {
      ActivityItem
    },
    data() {
      return {
        items: [
          {
            id: 1,
            name: "Check google.com",
            success : true,
            errorMessage : ""            
          },
          {
            id: 2,
            name: "Check the database",
            success : false,
            errorMessage : "connection timeout"
          },
          {
            id: 3,
            name: "Ping a Windows 2003 server",
            success : true,
            errorMessage : " was successful"
          }
        ]
      };
    }
  };
</script>