<template>
  <div>
    <ul v-if="items.length">
      <StatusItem 
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
  import StatusItem from "./StatusItem.vue";

  export default {
    components: {
      StatusItem
    },
    data() {
      return {
        items: [
          {
            id: 1,
            text: "'Check google.com' was successful",
            success : true,
            errormessage : ""            
          },
          {
            id: 2,
            text: "'Check the database' failed (connection timeout)",
            success : false,
            errormessage : ""
          },
          {
            id: 3,
            text: "'Ping a Windows 2003 server' was successful",
            success : true,
            errormessage : ""
          }
        ]
      };
    }
  };
</script>