<template>
  <li>
    {{ item.text }}
    <button @click="$emit('remove', item.id)">
      X
    </button>
  </li>
</template>

<script>
export default {
  props: {
    item: {
      type: Object,
      required: true
    }
  }
}
</script>