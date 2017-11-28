<template>
  <div>
    <table class="table table-striped" v-if="items.length">
      <tbody>
        <ManageItem 
          v-for="item in items" 
          :key="item.id" 
          :item="item" 
          @remove="removeTodo" />
      </tbody>
    </table>
    <p v-else>
      Nothing here.
    </p>
  </div>
</template>

<script>
  import ManageItem from "./ManageItem.vue";

  export default {
    components: {
      ManageItem
    },
    data() {
      return {
        newItemText: "",
        items: [
          {
            id: 1,
            text: "Check google.com"
          },
          {
            id: 2,
            text: "Check the database"
          },
          {
            id: 3,
            text: "Ping a Windows 2003 server"
          }
        ]
      };
    },
    methods: {
      addItem() {
        // TODO: push via the API
      },
      removeTodo(idToRemove) {
        // TODO: remove via the API
      }
    }
  };
</script>